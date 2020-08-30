using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Authentication
{
    public class AuthenticationProcess
    {
        public static Response ProcessAuthentication(User user)
        {
            Response response = new Response
            {
                ResponseApi = false
            };
            List<User> users = User.Userlists();
            User listedUser = users.FirstOrDefault(x=>x.Name==user.Name);
            if (listedUser!=null)
            {
                response.ResponseApi = user.Password == listedUser.Password? true : response.ResponseApi;
            }
          
            return response;
        }
    }
}