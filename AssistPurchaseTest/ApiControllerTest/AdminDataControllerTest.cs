using System.Net;
using AssistPurchase.Controllers;
using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using RestSharp;

namespace AssistPurchaseTest.ApiControllerTest
{
    public class AdminDataControllerTest : InMemoryContext
    {
        public readonly ProductDatabaseHandler Service;
        private readonly AdminDataController _controller;
        
        public AdminDataControllerTest()
        {
            Service = new ProductDatabaseHandler(Context);
            _controller = new AdminDataController(Service);
        }

        [Fact]
        public void GetAllProducts()
        {
            IActionResult response = _controller.Get();
            string result = response.ToString();
            Assert.False( result.Equals(""));
        }





        // Add test case
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new ProductInput
            {
                Id = "ADC103",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.True(badResponse == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void Add_ValidObjectPassedAlreadyPresent_ReturnsUnAuth()
        {

            var testItem = new ProductInput()
            {
                Id = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };

            var createdResponse = _controller.Post(testItem);

            Assert.True(createdResponse == HttpStatusCode.Unauthorized);
        }

        [Fact]
        public void Add_ValidObjectPassedReturnsOkResult()
        {

            var testItem = new ProductInput()
            {
                Id = "ADT10",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };

            var createdResponse = _controller.Post(testItem);

            Assert.True(createdResponse == HttpStatusCode.OK);

        }
        //  remove test case
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            var badResponse = _controller.Delete("X001");

            Assert.True(badResponse == HttpStatusCode.NotFound);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {

            var okResponse = _controller.Delete("ADT100");

            Assert.True(okResponse == HttpStatusCode.OK);
        }
        // Update Test Cases
        [Fact]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            var Item = new ProductInput
            {
                Id = "ADT20",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };
            var response = _controller.Post(Item);
            Item.Weight = "3.3";
            response = _controller.Put(Item);

            Assert.True(response == HttpStatusCode.OK);
        }
    }
}
