using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace assist_purchase_integration_test
{
    [TestClass]
    public class UnitTest1
    {
        public RestClient restClient = new RestClient("http://localhost:53010/api/");
        [TestMethod]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new ProductInput
            {
                UID = "ADC103",
                Name = null,
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };
            var restRequest = new RestRequest("AdminData/new", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(nameMissingItem));
            IRestResponse badResponse = restClient.Execute(restRequest);
            Assert.AreEqual(badResponse.Content, "400");
        }
        [TestMethod]
        public void Add_ValidObjectPassedAlreadyPresent_ReturnsUnAuth()
        {

            var testItem = new ProductInput()
            {
                UID = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };

            var restRequest = new RestRequest("AdminData/new", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);

            Assert.AreEqual(createdResponse.Content, "401");
        }

        [TestMethod]
        public void Add_ValidObjectPassedReturnsOkResult()
        {

            var testItem = new ProductInput()
            {
                UID = "AD1234",
                Name = "IntelliVue X3",
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };

            var restRequest = new RestRequest("AdminData/new", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);

            Assert.AreEqual(createdResponse.Content, "200");

            var restRequest2 = new RestRequest("AdminData/remove/AD1234", Method.DELETE);
            IRestResponse createdResponse2 = restClient.Execute(restRequest2);
            Assert.AreEqual(createdResponse2.Content, "200");
        }

        [TestMethod]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            var restRequest2 = new RestRequest("AdminData/remove/X0001", Method.DELETE);
            IRestResponse createdResponse2 = restClient.Execute(restRequest2);
            Assert.AreEqual(createdResponse2.Content, "404");

           
        }

        [TestMethod]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new ProductInput
            {
                UID = null,
                Name = null,
                DisplaySize = "6",
                DisplayType = "LCC",
                Weight = "1.3",
                TouchScreen = true
            };
            var restRequest = new RestRequest("AdminData/update", Method.PUT);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(nameMissingItem));
            IRestResponse badResponse = restClient.Execute(restRequest);

            Assert.AreEqual(badResponse.Content, "400");
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var restRequest = new RestRequest("AdminData", Method.GET);
            IRestResponse<List<Product>> okResult = restClient.Execute<List<Product>>(restRequest);
            Assert.AreEqual(okResult.Data[0].DisplaySize, 6);
        }

        [TestMethod]
        public void Get_WhenName_ReturnsOkResult()
        {
            var restRequest = new RestRequest("UserData/productbyname/Intellivue190", Method.GET);
            IRestResponse<Product> okResult = restClient.Execute<Product>(restRequest);
            Assert.AreEqual(okResult.Data.DisplaySize, 12);
        }

        [TestMethod]
        public void Add_InvalidSalesObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new Sales
            {
                EmailId = "tom123@gmail.com",
                Description = "Message",
            };
            var restRequest = new RestRequest("SalesData/contactsales", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(nameMissingItem));
            IRestResponse badResponse = restClient.Execute(restRequest);
            Assert.AreEqual(badResponse.Content, "400");
        }

        [TestMethod]
        public void Add_ValidSalesObjectPassedAlreadyPresent_ReturnsUnAuth()
        {

            var testItem = new Sales()
            {
                CustomerName = "tom",
                EmailId = "tom123@gmail.com",
                Description = "Message",
            };

            var restRequest = new RestRequest("SalesData/contactsales", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);

            Assert.AreEqual(createdResponse.Content, "401");
        }
        [TestMethod]
        public void GetAllAlerts_WhenCalled_ReturnsOkResult()
        {
            var restRequest = new RestRequest("SalesData/allalerts", Method.GET);
            IRestResponse<List<Sales>> okResult = restClient.Execute<List<Sales>>(restRequest);
            Assert.AreEqual(okResult.Data[0].CustomerName, "Subject");
        }
    }
}
