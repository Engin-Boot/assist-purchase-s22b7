using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;

using Microsoft.AspNetCore.Mvc;
using System;

using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDataController : ControllerBase
    {
        private readonly IProductDatabaseHandler _productDatabaseHandler;

        public AdminDataController(IProductDatabaseHandler repo)
        {
            _productDatabaseHandler = repo;
        }

        private static Product ProductInputToProduct(string displaySize, string weight, string displayType, string id, string name, bool touchScreen) 
        {
            var p = new Product
            {
                DisplaySize = int.Parse(displaySize),
                Weight = double.Parse(weight),
                DisplayType = displayType,
                Id = id,
                Name = name,
                TouchScreen = touchScreen
            };
            return p;
        }
        //Get api/AdminData
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productDatabaseHandler.GetAllProductsFromDb());
            }
            catch (Exception)
            { 
                return StatusCode(500);
            }
        }

        // POST api/new
        [HttpPost("new")]
        public HttpStatusCode Post([FromBody] ProductInput product)
        {
            if (string.IsNullOrEmpty(product.Name))
                //Console.WriteLine(product.Name);
                return HttpStatusCode.BadRequest;
            var p = ProductInputToProduct(product.DisplaySize, product.Weight, product.DisplayType, product.Id, product.Name, product.TouchScreen);
            return _productDatabaseHandler.AddProductToDb(p);
        }

        // PUT api/update
        [HttpPut("update")]
        public HttpStatusCode Put([FromBody] ProductInput prod)
        {
            if (string.IsNullOrEmpty(prod.Id))
                return HttpStatusCode.BadRequest;
            var p = ProductInputToProduct(prod.DisplaySize, prod.Weight, prod.DisplayType, prod.Id, prod.Name, prod.TouchScreen);
            return _productDatabaseHandler.UpdateProductInDb(p);
        }

        // DELETE api/remove/5
        [HttpDelete("remove/{id}")]
        public HttpStatusCode Delete(string id)
        {
            return id == null ? HttpStatusCode.BadRequest : _productDatabaseHandler.RemoveProductFromDb(id);
        }

    }
}
