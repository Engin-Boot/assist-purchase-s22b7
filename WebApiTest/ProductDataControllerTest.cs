using System;
using Xunit;
using AssistPurchase.Controllers;
using AssistPurchase.Repository;
using System.Collections.Generic;
using AssistPurchase.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest
{
    public class ProductDataControllerTest
    {
        ////private readonly IProductDataRepository repository;
        //ProductDataController _controller;
        //IProductDataRepository _repository;
        //IServiceProvider _provider;

        //public ProductDataControllerTest()
        //{
        //    _repository = new ProductMemoryDBRepository();
        //    _controller = new ProductDataController(_repository,_provider);
        //}


        //[Fact]
        //public void TestShowAllPRoducts()
        //{
        //    var productList = _repository.GetAllProducts();
        //    Assert.True(productList.Any());
        //}
        //[Fact]
        //public void TestGetProductById()
        //{

        //    var productList = _repository.GetAllProducts();

        //   // Assert.True(productList.Contains());
        //}

        //[Fact]
        //public void TestAddProduct()
        //{
        //    var testProduct = new ProductDataModel
        //    {
        //        ProductId = "X004",
        //        ProductName = "display4"
        //    };
        //    Assert.True(_repository.AddNewProduct(testProduct));
        //}

        //[Fact]
        //public void TestDeleteProduct()
        //{
        //    var testProduct = new ProductDataModel
        //    {
        //        ProductId="X001",
        //        ProductName="display1"
        //    };
        //    Assert.True(_repository.Remove(testProduct.ProductId));

        //    var testProduct1 = new ProductDataModel
        //    {
        //        ProductId = "X007",
        //        ProductName = "display7"
        //    };
        //    Assert.False(_repository.Remove(testProduct1.ProductId));
        //}

        //[Fact]
        //public void UpdateAddProduct()
        //{
        //    var testProduct = new ProductDataModel
        //    {
        //        ProductId = "X001",
        //        ProductName = "display2"
        //    };
        //    Assert.True(_repository.UpdateProductInfo(testProduct.ProductId,testProduct));
        //    var testProduct1 = new ProductDataModel
        //    {
        //        ProductId = "X008",
        //        ProductName = "display2"
        //    };
        //    Assert.False(_repository.UpdateProductInfo(testProduct1.ProductId, testProduct1));
        //}

        //Test for Get Method
        
        ProductDataController _controller;
        IProductDataRepository _repository;
        IServiceProvider _provider;

        public ProductDataControllerTest()
        {
            _repository = new ProductRepositoryTest();
            _controller = new ProductDataController(_repository,_provider);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ProductDataModel>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        //Test for Get By Id
        [Fact]
        public void GetById_UnknownIdPassedReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get("X001");
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get("X3");
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var okResult = _controller.Get("X3").Result as OkObjectResult;
            // Assert
            Assert.IsType<ProductDataModel>(okResult.Value);
            Assert.Equal("X3", (okResult.Value as ProductDataModel).ProductId);
        }

        // Test for Add New Product
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            //All parameters are not passed
            // Arrange
            var nameMissingItem = new ProductDataModel()
            {
                ProductName = "IntelliVue",
                ProductId = "MX001",
                ProductPrice = "10000",
                TouchScreen = "Yes",
                DisplaySize = "9",
                DisplayType = "LCD",
                Battery = "No",
                BatteryCapacity = "0",
                Portability = "No",
            };
            _controller.ModelState.AddModelError("Wearable","Weight");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ProductDataModel testItem = new ProductDataModel()
            {
                ProductName = "IntelliVue",
                ProductId = "MX001",
                ProductPrice = "10000",
                TouchScreen = "Yes",
                DisplaySize = "9",
                DisplayType = "LCD",
                Battery = "No",
                BatteryCapacity = "0",
                Portability = "No",
                Weight = "1.5",
                Wearable = "No",
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseOfCreatedItem()
        {
            // Arrange
            var testItem = new ProductDataModel()
            {
                ProductName = "IntelliVue",
                ProductId = "MX001",
                ProductPrice = "10000",
                TouchScreen = "Yes",
                DisplaySize = "9",
                DisplayType = "LCD",
                Battery = "No",
                BatteryCapacity = "0",
                Portability = "No",
                Weight = "1.8",
                Wearable = "No",
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as ProductDataModel;

            // Assert
            Assert.IsType<ProductDataModel>(item);
            Assert.Equal("MX001", item.ProductId);
            Assert.Equal("No", item.Wearable);
        }


        //Test for Remove Method
        [Fact]
        public void Remove_NotExistingId_ReturnsNotFoundResponse()
        {
            // Act
            var badResponse = _controller.Delete("X001");

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Act
            var okResponse = _controller.Delete("X3");

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {

            // Act
            var okResponse = _controller.Delete("X3");

            // Assert
            Assert.Equal(4, _repository.GetAllProducts().Count());
        }

    }
}
