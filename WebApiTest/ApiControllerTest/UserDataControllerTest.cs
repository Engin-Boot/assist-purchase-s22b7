using AssistPurchase.Controllers;
using AssistPurchase.Models;
using AssistPurchase.Repository;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace WebApiTest
{

    public class UserDataControllerTest
    {
        //Test for Get Method
        readonly UserDataController _controller;
        readonly IUserDataRepository _repository;

        public UserDataControllerTest()
        {
            _repository = new UserMemoryDBRepository();
            _controller = new UserDataController(_repository);
        }
        [Fact]
        public void StatusCodeTest()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api/userdata");
            RestRequest request = new RestRequest("all", Method.GET);

            // act
            IRestResponse response = client.Execute(request);


            // assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            //Assert.True(response.StatusDescription == HttpResponseMessag);
            //Assert.Contains("X3", response.Content);
        }

        //Test to Get All Products
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {

            var okResult = _controller.Get().Result as OkObjectResult;
            var items = Assert.IsType<List<ProductDataModel>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassedReturnsNotFoundResult()
        {
            var notFoundResult = _controller.Get("X001");
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
