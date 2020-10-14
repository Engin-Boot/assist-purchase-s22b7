using System;
using Xunit;
using AssistPurchase.Controllers;
using AssistPurchase.Repository;
using System.Collections.Generic;
using AssistPurchase.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using AssistPurchase.Models;
using System.Net.Http;

namespace WebApiTest
{

    public class UserDataControllerTest
    {
        //Test for Get Method
        readonly UserDataController _controller;
        readonly IUserDataRepository _repository;
        readonly IServiceProvider _provider;

        public UserDataControllerTest()
        {
            _repository = new UserMemoryDBRepository();
            _controller = new UserDataController(_repository, _provider);
        }
        [Fact]
        public void StatusCodeTest()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:53010/api/userdata");
            RestRequest request = new RestRequest("all", Method.GET);

            // act
            IRestResponse response = client.Execute(request);
           

            // assert
            Assert.True(response.StatusCode== HttpStatusCode.OK);
            //Assert.True(response.StatusDescription == HttpResponseMessag);
            //Assert.Contains("X3", response.Content);
        }

        //Test to Get All Products
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
    }
}
