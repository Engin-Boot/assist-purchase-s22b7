using Xunit;
using AssistPurchase.Controllers;
using DatabaseManager;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AssistPurchaseTest
{
    public class AdminDataControllerTest
    {
        private ProductDatabaseHandler _service;
        AdminDataController _controller;
 
        public AdminDataControllerTest()
        {
            _service = new ProductDatabaseHandler();
            _controller = new AdminDataController(_service);
        }
        // Add test case
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new Product
            {
                Id = "ADC103",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true,
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {

            var testItem = new Product()
            {
                Id = "ADC103",
                Name= "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true,
            };

            var createdResponse = _controller.Post(testItem);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        //  remove test case
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            var badResponse = _controller.Delete("X001");

            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {

            var okResponse = _controller.Delete("ADC103");

            Assert.IsType<OkResult>(okResponse);
        }
        // Update Test Cases
        [Fact]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new Product
            {
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true,
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Update_ValidObjectPassed_ReturnsCreatedResponse()
        {

            var testItem = new Product()
            {
                Id = "ADC103",
                Name = "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true,
            };

            var createdResponse = _controller.Post(testItem);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
            Assert.True(createdResponse == HttpStatusCode.OK);
        }
    }
}
