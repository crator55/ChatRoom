using API.BotAi;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "https://localhost:44341", headers: "*", methods: "*")]
    public class BotController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetResponseBot(Bot bot)
        {

            string result = BotAiResponse.GetResponseBot(bot.Command);
            return Ok(result);

        }
    }
}
