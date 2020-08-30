
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using API.Models;
using System.Web.Razor.Tokenizer.Symbols;

namespace API.BotAi
{
    public class BotAiResponse
    {
        public static string GetResponseBot(string message)
        {
            List<CsvFile> csvFiles = new List<CsvFile>();
            string[] data = File.ReadAllLines(@"C:\Users\rapto\Downloads\aapl.us.csv");
            for (int i = 1; i < data.Count(); i++)
            {
                string[] fields = data[i].Split(',');
                    CsvFile csvFile = new CsvFile()
                    {
                        Symbol =fields[0],
                        Date = DateTime.Parse(fields[1]),
                        Time = TimeSpan.Parse(fields[2]),
                        Open = decimal.Parse(fields[3]),
                        High = decimal.Parse(fields[4]),
                        Low = decimal.Parse(fields[5]),
                        Close = decimal.Parse(fields[6]),
                        Volume = Int32.Parse(fields[7])
                    };
                    csvFiles.Add(csvFile);

            }
            foreach (var item in csvFiles)
            {
                if (item.Symbol== message)
                {
                    string response = $"{item.Symbol} quote is ${item.High} per share";
                    return response;
                }
            }
            return "No command founded.";
        }
    }
}