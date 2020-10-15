using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        readonly Repository.IAlertRepository _alertDataRepository;
        public AlertController(Repository.IAlertRepository repo)
        {
            this._alertDataRepository = repo;
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
