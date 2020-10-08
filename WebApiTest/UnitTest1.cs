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
        ProductDataController _controller;
        IProductDataRepository _repository;
        IServiceProvider _provider;

        public ProductDataControllerTest()
        {
            _repository = new ProductMemoryDBRepository();
            _controller = new ProductDataController(_repository,_provider);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            
           // var products = _repository.GetAllProducts();
            //Assert.Equal({"productName":"display3","productId":"X003"}, products);
        }
    }
}
