using DatabaseContractor;
using DatabaseManager;
using System.Linq;
using System.Net;
using Xunit;

namespace AssistPurchaseTest.DatabaseManagerTest
{
    public class SalesDatabaseHandlerTest
    {

        readonly ISalesDatabaseHandler _salesDatabaseHandler;
        public SalesDatabaseHandlerTest()
        {
            _salesDatabaseHandler = new SalesDatabaseHandler();
        }

        [Fact]
        public void WhenRequestIsGoodThenAddInfoToDb()
        {
            var info = new Sales
            {
                CustomerName = "Subject1",
                EmailId = "Example@gmail.com",
                Description = "Contact"
            };

            var res = _salesDatabaseHandler.AddSalesToDb(info);
            Assert.True(res == HttpStatusCode.OK);

        }

        [Fact]
        public void WhenRequestIsGoodGetAllInfoFromDb()
        {
            var salesList = _salesDatabaseHandler.GetAllSales();
            Assert.True(salesList.Any());
        }
    }
}