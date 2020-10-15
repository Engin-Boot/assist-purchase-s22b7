using Xunit;
using AssistPurchase.Controllers;
using DatabaseManager;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;

namespace AssistPurchaseTest.ApiControllerTest
{
    public class SalesDataControllerTest
    {
        private SalesDatabaseHandler _service;
        SalesDataController _controller;

        public SalesDataControllerTest()
        {
            _service = new SalesDatabaseHandler();
            _controller = new SalesDataController(_service);
        }
        // Add test case
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new Sales
            {
               EmailId="tom123@gmail.com",
               Description="Message",
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {

            var testItem = new Sales()
            {
                CustomerName="tom",
                EmailId="tom123@gmail.com",
                Description="Message",
            };

            var createdResponse = _controller.Post(testItem);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        // Get Test Cases
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllInfo();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
