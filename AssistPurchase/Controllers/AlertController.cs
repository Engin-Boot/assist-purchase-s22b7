using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        readonly Repository.IAlertRepository _alertDataRepository;
        readonly IServiceProvider _provider;
        public AlertController(Repository.IAlertRepository repo, IServiceProvider provider)
        {
            this._alertDataRepository = repo;
            this._provider = provider;

        }
        // GET: api/<AlertController>
        [HttpPost("requestalert")]
        public ActionResult Post([FromBody] Models.AlertDataModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var request = _alertDataRepository.AddNewUserRequest(value);
            return CreatedAtAction("Get", new { name = request.CustomerName }, request);
        }

        //get all alerts
        [HttpGet("allalerts")]
        public ActionResult<IEnumerable<Models.AlertDataModel>> Get()
        {
            var requests = _alertDataRepository.GetAllAlertRequests();
            return Ok(requests);
        }
    }
}
