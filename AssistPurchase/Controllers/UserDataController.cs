using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;

using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IProductDatabaseHandler _productDatabaseHandler;
        private readonly IFilterDatabaseHandler _filterDatabaseHandler;

        public UserDataController(IProductDatabaseHandler productDatabase, IFilterDatabaseHandler filterDatabase)
        {
            _productDatabaseHandler = productDatabase;
            _filterDatabaseHandler = filterDatabase;
        }

        // GET: api/all
        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            
            return Ok(_productDatabaseHandler.GetAllProductsFromDb());
            

        }

        // GET: api/filterList
        [HttpPost("filterList")]
        public IActionResult GetFilteredProduct([FromBody]FilterModel obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception();
                return Ok(_filterDatabaseHandler.GetFilteredProducts(obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("filterList/size")]
        public IActionResult GetFilteredProductBySize( [FromBody] FilterModel obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception();
                return Ok(_filterDatabaseHandler.GetFilteredProductsBySize(obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("filterList/weight")]
        public IActionResult GetFilteredProductByWeight( [FromBody] FilterModel obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception();
                return Ok(_filterDatabaseHandler.GetFilteredProductsByWeight(obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("filterList/touchScreen")]
        public IActionResult GetFilteredProductByTouch( [FromBody] FilterModel obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception();
                return Ok(_filterDatabaseHandler.GetFilteredProductsByTouch(obj));
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet("productByName/{name}")]
        public IActionResult GetProductByName(string name)
        {
            //if (name == null) return StatusCode(400);
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception();
                return Ok(_productDatabaseHandler.GetProductByNameFromDb(name));
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
