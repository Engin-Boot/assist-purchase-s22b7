using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDataController : ControllerBase
    {

       readonly Repository.IProductDataRepository _productDataRepository;
       
        readonly IServiceProvider _provider;
        public ProductDataController(Repository.IProductDataRepository repo, IServiceProvider provider)
        {
            this._productDataRepository = repo;
            this._provider = provider;

        }
        // GET: api/<ProductDataController>
        [HttpGet("all")]
        public ActionResult<IEnumerable<Models.ProductDataModel>> Get()
        {
            var items= _productDataRepository.GetAllProducts();
            return Ok(items);
        }

        // GET api/<ProductDataController>/5
        [HttpGet("{id}")]
        public ActionResult<Models.ProductDataModel> Get(string id)
        {
            var products = _productDataRepository.GetAllProducts();
            foreach (var product in products)
            {
                if (product.ProductId == id)
                {
                    return Ok(product);
                }
            }
            return NotFound();
        }

        // POST api/<ProductDataController>
        [HttpPost("new")]
        public ActionResult Post([FromBody] Models.ProductDataModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _productDataRepository.AddNewProduct(value);
            return CreatedAtAction("Get", new { id = item.ProductId }, item);
        }

        // PUT api/<ProductDataController>/5
        [HttpPut("update/{id}")]
        public void Put(string id, [FromBody] Models.ProductDataModel value)
        {
            _productDataRepository.UpdateProductInfo(id, value);
        }

        // DELETE api/<ProductDataController>/5
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(string id)
        {
            var existingItem = _productDataRepository.GetProductById(id);
            if(existingItem==null)
            {
                return NotFound();
            }
            _productDataRepository.Remove(id);
            return Ok();
        }

        //Sales Person Info
        // GET: api/<ProductDataController>
        [HttpGet("SalesPersonInfo")]
        public ActionResult<IEnumerable<Models.SalesPersonDataModel>> GetSalesPersonDetails()
        {
            var salesPersonInfo = _productDataRepository.GetSalesPersonDetails();
            return Ok(salesPersonInfo);
        }

        // PUT api/<ProductDataController>/5
        [HttpPut("updateSalesPersonInfo/{uid}")]
        public void Put(string uid, [FromBody] Models.SalesPersonDataModel value)
        {
            _productDataRepository.UpdateSalesPersonInfo(uid, value);
        }
    }
}
