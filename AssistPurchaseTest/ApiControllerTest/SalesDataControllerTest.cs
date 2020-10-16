using AssistPurchase.Controllers;
using DatabaseContractor;
using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

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
                EmailId = "tom123@gmail.com",
                Description = "Message",
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.True(badResponse == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void Add_ValidObjectPassedAlreadyPresent_ReturnsUnAuth()
        {

            var testItem = new Sales()
            {
                CustomerName = "tom",
                EmailId = "tom123@gmail.com",
                Description = "Message",
            };

            var createdResponse = _controller.Post(testItem);

            Assert.True(createdResponse == HttpStatusCode.Unauthorized);
        }

        // Get Test Cases
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetAllInfo();
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
