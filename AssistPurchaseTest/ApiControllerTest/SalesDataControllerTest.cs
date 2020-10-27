using AssistPurchase.Controllers;
using AssistPurchase.Repositories.SalesDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace AssistPurchaseTest.ApiControllerTest
{
    public class SalesDataControllerTest : InMemoryContext
    {
        private readonly SalesDataController _controller;

        public SalesDataControllerTest()
        {
            var service = new SalesDatabaseHandler(Context);
            _controller = new SalesDataController(service);
        }
        // Add test case
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new SalesInput
            {
                EmailId = "tom123@gmail.com",
                Description = new Product[0]
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.True(badResponse == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOK()
        {
            var nameMissingItem = new SalesInput
            {
                CustomerName="test",
                EmailId = "tom123@gmail.com",
                Description = new Product[0]
            };
            var response = _controller.Post(nameMissingItem);

            Assert.True(response == HttpStatusCode.OK);
        }
        //[Fact]
        //public void Add_ValidObjectPassedAlreadyPresent_ReturnsUnAuth()
        //{

        //  var testItem = new SalesInput()
        //  {
        //      CustomerName = "tom",
        //      EmailId = "tom123@gmail.com",
        //      Description = new Product[0]
        //  };

        //var createdResponse = _controller.Post(testItem);

        //Assert.True(createdResponse == HttpStatusCode.Unauthorized);
        //}

        // Get Test Cases
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetAllInfo();
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
