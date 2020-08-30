using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace SignalRChat
{
    public  class ChatHub : Hub
    {
        static readonly HttpClient client = new HttpClient();
        public async Task Send(string name, string message)
        {
           
            if (message.Contains("/stock="))
            {
            string botMessage= message.Replace("/stock=", "");
                try
                {
                   var newJson= new  { Command= botMessage };
                    var json = JsonConvert.SerializeObject(newJson);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var url = "http://localhost:49861/api/Bot/GetResponseBot";
                    var client = new HttpClient();

                    var response = await client.PostAsync(url, data);
                    string botName = "RabbitMQ";
                    string result = response.Content.ReadAsStringAsync().Result;
                    Clients.All.broadcastMessage(botName, result);
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                Clients.All.broadcastMessage(name, message);
            }
          
        }
    }
}