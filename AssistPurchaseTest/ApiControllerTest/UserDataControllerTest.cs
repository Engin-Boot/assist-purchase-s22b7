using AssistPurchase.Controllers;
using DatabaseContractor;
using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssistPurchaseTest.ApiControllerTest
{
    public class UserDataControllerTest
    {
        readonly private ProductDatabaseHandler _service;
        readonly private FilterDatabaseHandler _filterservice;
        readonly UserDataController _controller;

        public UserDataControllerTest()
        {
            _service = new ProductDatabaseHandler();
            _filterservice = new FilterDatabaseHandler();
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

        /*
        [Fact]
        public void Get_WhenCalledByFilter_ReturnsOkResult()
        {
            var filter1 = new FilterModel
            {
                TouchScreen = false
            };
            var okResult = _controller.GetFilteredProduct(filter1);
            Assert.IsType<OkObjectResult>(okResult);
        }
        */
    }
}
