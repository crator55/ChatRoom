using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public static List<User> Userlists()
        {
            List<User> users = new List<User>();
            User user = new User()
            {//password coded with Base64 
                Name = "Diego",
                Password = "MTIzNDU2Nzg5"
            };
            User user2 = new User()
            {
                //password coded with Base64 
                Name = "Ana",
                Password = "OTg3NjU0MzIx"
            };
            users.Add(user);
            users.Add(user2);
            return users;
    }
    

    }
}