using AssistPurchase.Repositories.SalesDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;


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
        [HttpPost("contactsales")]
        public HttpStatusCode Post([FromBody] Sales info)
        {
            if (string.IsNullOrEmpty(info.CustomerName))
                return HttpStatusCode.BadRequest;
            return _salesDatabaseHandler.AddSalesToDb(info);
        }

        // GET: api/getallinfo
        [HttpGet("allalerts")]
        public IActionResult GetAllInfo()
        {
            try
            {
                return Ok(_salesDatabaseHandler.GetAllSales());
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                return StatusCode(500);
            }
        }
    }
}
