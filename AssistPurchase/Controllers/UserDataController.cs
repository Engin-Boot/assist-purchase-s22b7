using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        readonly IProductDatabaseHandler _productDatabaseHandler;
        readonly IFilterDatabaseHandler _filterDatabaseHandler;

        public UserDataController(IProductDatabaseHandler prepo, IFilterDatabaseHandler frepo)
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
        [HttpPost("filterlist")]
        public IActionResult GetFilteredProduct([FromBody]FilterModel Obj)
        {
            try
            {             
                return Ok(_filterDatabaseHandler.GetFilteredProducts(Obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("filterlist/size")]
        public IActionResult GetFilteredProductBySIze( [FromBody] FilterModel Obj)
        {
            try
            {
                return Ok(_filterDatabaseHandler.GetFilteredProductsBySize(Obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("filterlist/weight")]
        public IActionResult GetFilteredProductByWeight( [FromBody] FilterModel Obj)
        {
            try
            {
                return Ok(_filterDatabaseHandler.GetFilteredProductsByWeight(Obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("filterlist/touchscreen")]
        public IActionResult GetFilteredProductByTouch( [FromBody] FilterModel Obj)
        {
            try
            {
                return Ok(_filterDatabaseHandler.GetFilteredProductsByTouch(Obj));
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
