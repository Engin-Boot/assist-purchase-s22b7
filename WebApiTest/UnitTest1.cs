using System;
using Xunit;
using AssistPurchase.Controllers;
using AssistPurchase.Repository;
using System.Collections.Generic;
using AssistPurchase.Models;
using System.Linq;

namespace WebApiTest
{
    public class ProductDataControllerTest
    {
        //private readonly IProductDataRepository repository;
        ProductDataController _controller;
        IProductDataRepository _repository;
        IServiceProvider _provider;

        public ProductDataControllerTest()
        {
            _repository = new ProductMemoryDBRepository();
            _controller = new ProductDataController(_repository,_provider);
        }


        [Fact]
        public void TestShowAllPRoducts()
        {
            var productList = _repository.GetAllProducts();
            Assert.True(productList.Any());
        }

        [Fact]
        public void TestAddProduct()
        {
            var testProduct = new ProductDataModel
            {
                ProductId = "X004",
                ProductName = "display4"
            };
            Assert.True(_repository.AddNewProduct(testProduct));
        }

        [Fact]
        public void TestDeleteProduct()
        {
            var testProduct = new ProductDataModel
            {
                ProductId="X001",
                ProductName="display1"
            };
            Assert.True(_repository.Remove(testProduct.ProductId));

            var testProduct1 = new ProductDataModel
            {
                ProductId = "X007",
                ProductName = "display7"
            };
            Assert.False(_repository.Remove(testProduct1.ProductId));
        }

        [Fact]
        public void UpdateAddProduct()
        {
            var testProduct = new ProductDataModel
            {
                ProductId = "X001",
                ProductName = "display2"
            };
            Assert.True(_repository.UpdateProductInfo(testProduct.ProductId,testProduct));
            var testProduct1 = new ProductDataModel
            {
                ProductId = "X008",
                ProductName = "display2"
            };
            Assert.False(_repository.UpdateProductInfo(testProduct1.ProductId, testProduct1));
        }

    }
}
