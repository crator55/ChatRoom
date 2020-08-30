using API.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using API.Authentication;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "https://localhost:44341", headers: "*", methods: "*")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
      
        public IHttpActionResult GetAuth(User user)
        {
          Response result =  AuthenticationProcess.ProcessAuthentication(user);
           
          return Ok(result);
           
        }
    }
}
