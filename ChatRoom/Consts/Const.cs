using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Consts
{
    public class Const
    {
        public Const()
        {
            CodeBot = "/stock=";
            BotName = "RabbitMQ";
            Url = "http://localhost:49861/api/Bot/GetStock";
        }

        public  string CodeBot { get; set; }
        public  string BotName { get; set; }
        public  string Url { get; set; }
       
    }
}