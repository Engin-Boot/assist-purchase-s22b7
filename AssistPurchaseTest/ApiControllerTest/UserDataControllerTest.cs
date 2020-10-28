using AssistPurchase.Controllers;
using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace AssistPurchaseTest.ApiControllerTest 
{
  
    public class UserDataControllerTest : InMemoryContext
    {
        private readonly ProductDatabaseHandler Service;
        private readonly FilterDatabaseHandler FilterService;
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

        [Fact]
        public void Get_WhenName_ReturnsOkResult_Null()
        {
            var okResult = _controller.GetProductByName(null);
            Assert.IsNotType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetFilterByType()
        {
            var filter1 = new FilterModel
            {

                DisplayType = new List<string>{ "LCC" }

            };

            var okResult = _controller.GetFilteredProduct(filter1);
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void GetFilterBySize()
        {
            var filter1 = new FilterModel
            {

                DisplaySize = new Limits { Max = "25", Min = "0" }

            };

            var okResult = _controller.GetFilteredProductBySize(filter1);
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void GetFilterByWeight()
        {
            var filter1 = new FilterModel
            {

                Weight = new Limits { Max = "25", Min = "0" }

            };

            var okResult = _controller.GetFilteredProductByWeight(filter1);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetFilterByTouch()
        {
            var filter1 = new FilterModel
            {

                TouchScreen = true

            };

            var okResult = _controller.GetFilteredProductByTouch(filter1);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetFilterByTouchFalse()
        {
            var filter1 = new FilterModel
            {

                TouchScreen = false

            };

            var okResult = _controller.GetFilteredProductByTouch(filter1);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void WhenNullPassedGetFilteredProductThenStatus500()
        {
            var response = _controller.GetFilteredProduct(null);
            var okResult = response as OkObjectResult;
            Assert.True(okResult  == null);
        }

        [Fact]
        public void WhenNullPassedGetFilteredProductBySizeThenStatus500()
        {
            var response = _controller.GetFilteredProductBySize(null);
            var okResult = response as OkObjectResult;
            Assert.True(okResult == null);
        }

        [Fact]
        public void WhenNullPassedGetFilteredProductByWeightThenStatus500()
        {
            var response = _controller.GetFilteredProductByWeight(null);
            var okResult = response as OkObjectResult;
            Assert.True(okResult == null);
        }

        [Fact]
        public void WhenNullPassedGetFilteredProductByTouchThenStatus500()
        {
            var response = _controller.GetFilteredProductByTouch(null);
            var okResult = response as OkObjectResult;
            Assert.True(okResult == null);
        }

        [Fact]
        public void WhenNullPassedGetProductByNameThenStatus500()
        {
            var response = _controller.GetProductByName("");
            var okResult = response as OkObjectResult;
            Assert.True(okResult == null);
        }
    }
}
