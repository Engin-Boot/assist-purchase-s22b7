using AssistPurchase.Controllers;
using AssistPurchase.Repositories.SalesDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace AssistPurchaseTest.ApiControllerTest
{
    public class SalesDataControllerTest : AssistPurchaseTest.ApiControllerTest.InMemoryContext
    {
        private SalesDatabaseHandler _service;
        SalesDataController _controller;

        public SalesDataControllerTest()
        {
            _service = new SalesDatabaseHandler(Context);
            _controller = new SalesDataController(_service);
        }
        // Add test case
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new SalesInfo
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

            var testItem = new SalesInput()
            {
                CustomerName = "tom",
                EmailId = "tom123@gmail.com",
                Description = new Product[0]
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
