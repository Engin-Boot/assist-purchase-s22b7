using AssistPurchase.Repositories.SalesDatabase;
using DatabaseContractor;
using System.Linq;
using System.Net;
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

        [Fact]
        public void WhenRequestIsGoodThenAddInfoToDbReturnUnAuthIfPresent()
        {
            var info = new Sales
            {
                CustomerName = "Subject24",
                EmailId = "Example4@gmail.com",
                Description = "Contact2"
            };

            var res = _salesDatabaseHandler.AddSalesToDb(info);
            Assert.True(res == HttpStatusCode.Unauthorized);

        }

        [Fact]
        public void WhenRequestIsGoodGetAllInfoFromDb()
        {
            var salesList = _salesDatabaseHandler.GetAllSales();
            Assert.True(salesList.Any());
        }
    }
}