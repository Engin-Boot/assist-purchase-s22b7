using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDataController : ControllerBase
    {

        readonly IProductDatabaseHandler _productDatabaseHandler;

        public AdminDataController(IProductDatabaseHandler repo)
        {
            _productDatabaseHandler = repo;
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
        public HttpStatusCode Post([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                return HttpStatusCode.BadRequest;

            return _productDatabaseHandler.AddProductToDb(product);
        }

        // PUT api/update
        [HttpPut("update")]
        public HttpStatusCode Put([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Id))
                return HttpStatusCode.BadRequest;

            return _productDatabaseHandler.UpdateProductInDb(product);
        }

        // DELETE api/remove/5
        [HttpDelete("remove/{id}")]
        public HttpStatusCode Delete(string id)
        {
            if (id == null)
                return HttpStatusCode.BadRequest;
            return _productDatabaseHandler.RemoveProductFromDb(id);
        }

    }
}
