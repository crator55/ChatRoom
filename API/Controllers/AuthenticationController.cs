using API.Models;
using System.Web.Http;
using API.Authentication;
using System.Web.Http.Cors;


namespace API.Controllers
{
    
    [RoutePrefix("api/Auth")]
    [EnableCors(origins: "https://localhost:44341", headers: "*", methods: "POST")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [Route("AuthProcess")]
        public IHttpActionResult GetAuth(User user)
        {
          Response result =  AuthenticationProcess.ProcessAuthentication(user);
          return Ok(result);
        }
    }
}
