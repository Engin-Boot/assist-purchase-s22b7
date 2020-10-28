
using AssistPurchase.Repositories.SalesDatabase;

using System.Linq;

using Xunit;

namespace AssistPurchaseTest.DatabaseManagerTest
{
    public class SalesDatabaseHandlerTest : ApiControllerTest.InMemoryContext
    {

        readonly ISalesDatabaseHandler _salesDatabaseHandler;
        public SalesDatabaseHandlerTest()
        {
            _salesDatabaseHandler = new SalesDatabaseHandler(Context);
        }

        //[Fact]
        //public void WhenRequestIsGoodThenAddInfoToDbReturnUnAuthIfPresent()
        //{
        //    var info = new SalesInput
        //    {
        //        CustomerName = "Subject24",
        //        EmailId = "Example4@gmail.com",
        //        Description = new Product[0]
        //        
        //    };
        //
        //    var res = _salesDatabaseHandler.AddSalesToDb(info);
        //    Assert.True(res == HttpStatusCode.Unauthorized);

        //}

        [Fact]
        public void WhenRequestIsGoodGetAllInfoFromDb()
        {
            var salesList = _salesDatabaseHandler.GetAllSales();
            Assert.True(salesList.Any());
        }

        //[Fact]
        //public void EmailAlerterTest()
        //{
        //    EmailAlert alerter = new EmailAlert();
        //    SalesInput salesInput = new SalesInput()
        //    {
        //        CustomerName="AnanyaTest",
        //        EmailId="TestId",
        //        Description=new Product[0]
        //    };
        //    var response=alerter.Alert(salesInput);
        //    Assert.True(response);
        //}

        //[Fact]
        //public void EmailAlerterTestForMultipleDescriptions()
        //{
        //    EmailAlert alerter = new EmailAlert();
        //    var info = new SalesInput
        //    {
        //        CustomerName = "Subject24",
        //        EmailId = "Example4@gmail.com",
        //        Description = new Product[3]
        //    };
        //    for (int i = 0; i < 3; i++)
        //    {
        //        info.Description[i] = new Product
        //        {
        //            Id = "ADC578",
        //            DisplaySize = 15,
        //            DisplayType = "LCD",
        //            Name = "IntelliVue X2",
        //            TouchScreen = true,
        //            Weight = 5
        //        };
        //    }


        //    var response = alerter.Alert(info);
        //    Assert.True(response);

        //}

    }
}