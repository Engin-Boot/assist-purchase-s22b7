using AssistPurchase.Controllers;
using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssistPurchaseTest.ApiControllerTest 
{
  
    public class UserDataControllerTest : AssistPurchaseTest.ApiControllerTest.InMemoryContext
    {
        readonly private ProductDatabaseHandler _service;
        readonly private FilterDatabaseHandler _filterservice;
        readonly UserDataController _controller;

        public UserDataControllerTest()
        {
            _service = new ProductDatabaseHandler(Context);
            _filterservice = new FilterDatabaseHandler(Context);
            _controller = new UserDataController(_service, _filterservice);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetAllProducts();
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenName_ReturnsOkResult()
        {
            var okResult = _controller.GetProductByName("ADC100");
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
