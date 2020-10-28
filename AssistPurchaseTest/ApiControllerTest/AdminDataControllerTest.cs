using System.Net;
using AssistPurchase.Controllers;
using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static Xunit.Assert;

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

            True(badResponse == HttpStatusCode.BadRequest);
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

            True(createdResponse == HttpStatusCode.Unauthorized);
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

            True(createdResponse == HttpStatusCode.OK);

        }
        //  remove test case
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            var badResponse = _controller.Delete("X001");

            True(badResponse == HttpStatusCode.NotFound);
        }

        [Fact]
        public void Remove_NullIdGuidPassed_ReturnsBadRequest()
        {
            var badResponse = _controller.Delete(null);

            True(badResponse == HttpStatusCode.BadRequest);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {

            var okResponse = _controller.Delete("ADT100");

            True(okResponse == HttpStatusCode.OK);
        }
        // Update Test Cases
        [Fact]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new ProductInput
            {
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };
            var badResponse = _controller.Post(nameMissingItem);

            True(badResponse == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void WhenUpdateProductWithNullIdThenStatusUnAuthorized() 
        {
            var testItem = new ProductInput()
            {
                Id = null,
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };
            var response = _controller.Put(testItem);
            True(response == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void WhenUpdateProductWhichIsNotPresentThenStatusNotFound()
        {
            var testItem = new ProductInput()
            {
                Id = "ADT10",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.5",
                TouchScreen = true
            };
            var response = _controller.Put(testItem);
            True(response == HttpStatusCode.NotFound);
        }

        [Fact]
        public void WhenUpdateProductWhichIsPresentThenStatusOk()
        {
            var testItem = new ProductInput()
            {
                Id = "ADT100",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.5",
                TouchScreen = true
            };
            var response = _controller.Put(testItem);
            True(response == HttpStatusCode.OK);
        }

        [Fact]
        public void TestForGettingAllPatient()
        {
            var response = _controller.Get();
            var okResult = response as OkObjectResult;
            True(200 == okResult.StatusCode);
        }
    }
}
