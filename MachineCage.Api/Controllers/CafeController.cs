using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using MachineCafe.DataAccess;
using MachineCafe.Model;

namespace MachineCafe.WebApi.Controllers
{
    public class CafeController : ApiController
    {
        private readonly IDeviceApi _api;
        private readonly IMachineRepository _repository;

        public CafeController(IDeviceApi api, IMachineRepository repository)
        {
            _api = api;
            _repository = repository;
        }
        [HttpPost]
        public async Task<IHttpActionResult> TurnOnMachine()
        {
            try
            {
                await _api.TurnOn(await _repository.GetLastState());
                return Ok();
            }
            catch (AggregateException ex)
            {
                return ResponseMessage(this.Request.CreateResponse(HttpStatusCode.Conflict, ex.Message));
            }
        }


    }
}