using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using System.Linq;
using Xunit;

namespace AssistPurchaseTest.DatabaseManagerTest
{
    public class FilterDatabaseHandlerTest : ApiControllerTest.InMemoryContext
    {
        readonly IFilterDatabaseHandler _filterDatabaseHandler;

        public FilterDatabaseHandlerTest()
        {
            _filterDatabaseHandler = new FilterDatabaseHandler(Context);
        }

        [Fact]
        public void FilterProductsBasedOnFilter()
        {
           
            FilterModel filter1 = new FilterModel
            {

                TouchScreen = true

            };

            var flist = _filterDatabaseHandler.GetFilteredProductsByTouch(filter1);
            Assert.True(flist.Any());

        }
    }
}
