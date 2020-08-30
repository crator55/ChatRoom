
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using API.Models;
using System.Web.Razor.Tokenizer.Symbols;
using System.Net.Http;
using API.Services;

namespace API.BotAi
{
    public class BotAiResponse : IStockGetter
    {
      
        public string GetResponseBot(string message)
        {
            HttpClient Client = new HttpClient();
            using (HttpResponseMessage response = Client.GetAsync($"https://stooq.com/q/l/?s={message}&f=sd2t2ohlcv&h&e=csv").Result)
            using (HttpContent content = response.Content)
            {
                var callResponse = content.ReadAsStringAsync().Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new ArgumentException(callResponse);
                var data = callResponse.Substring(callResponse.IndexOf(Environment.NewLine, StringComparison.Ordinal) + 2);
                var fields = data.Split(',');

                CsvFile csvFile = new CsvFile()
                {
                    Symbol = fields[0],
                    Date = !fields[1].Contains("N/D") ? DateTime.Parse(fields[1]):default,
                    Time = !fields[2].Contains("N/D") ? TimeSpan.Parse(fields[2]) : default,
                    Open = !fields[3].Contains("N/D") ? decimal.Parse(fields[3]) : default,
                    High = !fields[4].Contains("N/D") ? decimal.Parse(fields[4]) : default,
                    Low = !fields[5].Contains("N/D") ? decimal.Parse(fields[5]) : default,
                    Close = !fields[6].Contains("N/D") ? decimal.Parse(fields[6]) : default,
                    Volume = !fields[7].Contains("N/D") ? Int32.Parse(fields[7]) : default
                };
                if (csvFile.Symbol.Equals(message.ToUpper()))
                {
                    return $"{csvFile.Symbol} quote is ${csvFile.Close} per share";
                }

            }


            return "No command founded.";
        }
    }
}