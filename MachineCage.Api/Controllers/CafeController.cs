using System.Web.Http;
using System.Web.Http.Results;

namespace MachineCafe.WebApi.Controllers
{
    public class CafeController : ApiController
    {

        [HttpPost]
        public IHttpActionResult TurnOnMachine()
        {
            return Ok();
        }


    }
}