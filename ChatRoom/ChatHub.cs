using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            if (message.Contains("/stock="))
            {
            string botMesassge= message.Replace("/stock=", "");
                if (true)
                {

                }
            }
            Clients.All.broadcastMessage(name, message);
        }
    }
}