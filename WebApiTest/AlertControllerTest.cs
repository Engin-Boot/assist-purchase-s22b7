﻿using System;
using Xunit;
using AssistPurchase.Controllers;
using AssistPurchase.Repository;
using System.Collections.Generic;
using AssistPurchase.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest
{
    public class AlertControllerTest
    {
        //Test for Get Method
        readonly AlertController _controller;
        readonly IAlertRepository _repository;
        readonly IServiceProvider _provider;

        public AlertControllerTest()
        {
            _repository = new AlertDBRepository();
            _controller = new AlertController(_repository, _provider);
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
        //[Fact]
        //public void Get_WhenCalled_ReturnsAllItems()
        //{
        //    // Act
        //    var okResult = _controller.Get().Result as OkObjectResult;
        //    // Assert
        //    var items = Assert.IsType<List<ProductDataModel>>(okResult.Value);
        //    Assert.Equal(5, items.Count);
        //}
    }
}
