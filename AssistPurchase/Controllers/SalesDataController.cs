using AssistPurchase.Repositories.SalesDatabase;
using DatabaseContractor;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using AssistPurchase.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDataController : ControllerBase
    {
        readonly ISalesDatabaseHandler _salesDatabaseHandler;
        public SalesDataController(ISalesDatabaseHandler repo)
        {
            _salesDatabaseHandler = repo;
        }

        // POST: api/<AlertController>
        [HttpPost("contactSales")]
        public HttpStatusCode Post([FromBody] SalesInput info)
        {
            if (string.IsNullOrEmpty(info.CustomerName))
                return HttpStatusCode.BadRequest;
            IAlerter alerter = new EmailAlert();
            alerter.Alert(info);
            return _salesDatabaseHandler.AddSalesToDb(info);
        }

        // GET: api/allAlerts
        [HttpGet("allAlerts")]
        public IActionResult GetAllInfo()
        {
            
            return Ok(_salesDatabaseHandler.GetAllSales());
            
        }
    }
}
