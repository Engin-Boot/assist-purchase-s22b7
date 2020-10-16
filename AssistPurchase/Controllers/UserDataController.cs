using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        readonly DatabaseManager.IProductDatabaseHandler _productDatabaseHandler;
        readonly DatabaseManager.IFilterDatabaseHandler _filterDatabaseHandler;

        public UserDataController(DatabaseManager.IProductDatabaseHandler prepo, DatabaseManager.IFilterDatabaseHandler frepo)
        {
            _productDatabaseHandler = prepo;
            _filterDatabaseHandler = frepo;
        }

        // GET: api/all
        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productDatabaseHandler.GetAllProductsFromDb());
            }
            catch
            {
                return StatusCode(500);
            }

        }

        // GET: api/filterlist
        [HttpGet("filterlist")]
        public IActionResult GetFilteredProduct([FromBody] FilterModel filterObj)
        {
            try
            {
                return Ok(_filterDatabaseHandler.GetFilteredProducts(filterObj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("productbyname/{name}")]
        public IActionResult GetProductByName(string name)
        {
            if (name == null) return StatusCode(400);
            try
            {
                return Ok(_productDatabaseHandler.GetProductByNameFromDb(name));
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
