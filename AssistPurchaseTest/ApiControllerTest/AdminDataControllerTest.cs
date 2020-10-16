using AssistPurchase.Controllers;
using DatabaseContractor;
using DatabaseManager;
using System.Net;
using Xunit;

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
                TouchScreen = true
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.True(badResponse == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void Add_ValidObjectPassedAlreadyPresent_ReturnsUnAuth()
        {

            var testItem = new Product()
            {
                Id = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true
            };

            var createdResponse = _controller.Post(testItem);

            Assert.True(createdResponse == HttpStatusCode.Unauthorized);
        }

        [Fact]
        public void Add_ValidObjectPassedReturnsOkResult()
        {

            var testItem = new Product()
            {
                Id = "ADT100",
                Name = "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
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
            var nameMissingItem = new Product
            {
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true
            };
            var badResponse = _controller.Post(nameMissingItem);

            Assert.True(badResponse == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void Update_ValidObjectPassed_ReturnsCreatedResponse()
        {

            var testItem = new Product()
            {
                Id = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true
            };

            var createdResponse = _controller.Post(testItem);
            Assert.True(createdResponse == HttpStatusCode.OK);
        }
    }
}
