using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;

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

        public Product ProductInputToProduct(string ds, string w, string dt, string id, string n, bool ts) 
        {
            Product p = new Product
            {
                DisplaySize = int.Parse(ds),
                Weight = double.Parse(w),
                DisplayType = dt,
                Id = id,
                Name = n,
                TouchScreen = ts
            };
            return p;
        }
        //Get api/AdminData
        [HttpGet]
        public IActionResult Get()
        {
           
            return Ok(_productDatabaseHandler.GetAllProductsFromDb());
            
            
        }

        // POST api/new
        [HttpPost("new")]
        public HttpStatusCode Post([FromBody] ProductInput product)
        {
            if (string.IsNullOrEmpty(product.Name))
                //Console.WriteLine(product.Name);
                return HttpStatusCode.BadRequest;
            Product p = ProductInputToProduct(product.DisplaySize, product.Weight, product.DisplayType, product.Id, product.Name, product.TouchScreen);
            return _productDatabaseHandler.AddProductToDb(p);
        }

        // PUT api/update
        [HttpPut("update")]
        public HttpStatusCode Put([FromBody] ProductInput product)
        {
            if (string.IsNullOrEmpty(product.Id))
                return HttpStatusCode.BadRequest;
            Product p = ProductInputToProduct(product.DisplaySize, product.Weight, product.DisplayType, product.Id, product.Name, product.TouchScreen);


            return _productDatabaseHandler.UpdateProductInDb(p);
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
