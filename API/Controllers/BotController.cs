using API.BotAi;
using API.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{

    [RoutePrefix("api/bot")]

    [EnableCors(origins: "https://localhost:44341", headers: "*", methods: "*")]
    public class BotController : ApiController
    {
        [Route("GetStock")]
        [HttpPost]
        public IHttpActionResult GetResponseBot(Bot bot)
        {
            BotAiResponse botAiResponse = new BotAiResponse();
            string result = botAiResponse.GetResponseBot(bot.Command);
            return Ok(result);

        }
    }
}
