using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        Repository.IProductDataRepository _userDataRepository;
        IServiceProvider _provider;
        public UserDataController(Repository.IProductDataRepository repo, IServiceProvider provider)
        {
            this._userDataRepository = repo;
            this._provider = provider;

        }

        // GET: api/<UserDataController>
        [HttpGet("all")]
        public ActionResult<IEnumerable<Models.ProductDataModel>> Get()
        {
            var items = _userDataRepository.GetAllProducts();
            return Ok(items);
        }

        //[HttpGet("wearable/{value}")]
        //public ActionResult<IEnumerable<Models.ProductDataModel>> Get(string value)
        //{
        //    var items = _userDataRepository.GetAllProducts();
        //    return Ok(_userDataRepository.GetProductByWearability(value));
        //}

        // GET api/<UserDataController>/5
        [HttpGet("{id}")]
        public ActionResult<Models.ProductDataModel> Get(string id)
        {
            var products = _userDataRepository.GetAllProducts();
            foreach (var product in products)
            {
                if (product.ProductId == id)
                {
                    return Ok(product);
                }
            }
            return NotFound();
        }




       // POST api/<UserDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
