using DatabaseContractor;
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
        readonly DatabaseManager.SalesDatabase.ISalesDatabaseHandler _salesDatabaseHandler;
        public SalesDataController(DatabaseManager.SalesDatabase.ISalesDatabaseHandler repo)
        {
            _salesDatabaseHandler = repo;
        }

        // POST: api/<AlertController>
        [HttpPost("contactsales")]
        public HttpStatusCode Post([FromBody] Sales info) => _salesDatabaseHandler.AddSalesToDb(info);


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
        [HttpGet("alertbyname/{Cname}")]
        public IActionResult InfoByName([FromBody] string Cname)
        {
            try
            {
                return Ok(_salesDatabaseHandler.GetSalesByCustomerNameFromDb(Cname));
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                return StatusCode(500);
            }
        }

    }
}
