using AssistPurchase.Controllers;
using AssistPurchase.Repositories.ProductDatabase;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssistPurchaseTest.ApiControllerTest 
{
  
    public class UserDataControllerTest : InMemoryContext
    {
        public readonly ProductDatabaseHandler Service;
        public readonly FilterDatabaseHandler FilterService;
        private readonly UserDataController _controller;

        public UserDataControllerTest()
        {
            Service = new ProductDatabaseHandler(Context);
            FilterService = new FilterDatabaseHandler(Context);
            _controller = new UserDataController(Service, FilterService);
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
