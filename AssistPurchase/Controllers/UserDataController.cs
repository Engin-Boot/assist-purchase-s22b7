using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        Repository.IUserDataRepository _userDataRepository;
        public UserDataController(Repository.IUserDataRepository repo)
        {
            this._userDataRepository = repo;
        }

        // GET: api/<UserDataController>
        [HttpGet("all")]
        public ActionResult<IEnumerable<Models.ProductDataModel>> Get()
        {
            var items = _userDataRepository.GetAllProducts();
            return Ok(items);
        }

        // GET: api/<UserDataController>/wearable
        [HttpGet("wearable/{wearable}")]
        public ActionResult<IEnumerable<Models.ProductDataModel>> GetProductByWearability(string wearable)
        {
            var items = _userDataRepository.GetAllProducts();
            foreach (var product in items)
            {
                if (product.Wearable == wearable)
                {
                    return Ok(product);
                }
            }
            return NotFound();
        }

        [HttpGet("price/{price}")]
        public ActionResult<IEnumerable<Models.ProductDataModel>> GetProductByPrice(string price)
        {
            var items = _userDataRepository.GetAllProducts();
            foreach (var product in items)
            {
                if (product.ProductPrice == price)
                {
                    return Ok(product);
                }
            }
            return NotFound();
        }


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
    }
}
