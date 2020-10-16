using DatabaseContractor;
using DatabaseManager;
using System.Linq;
using Xunit;

namespace AssistPurchaseTest.DatabaseManagerTest
{
    public class FilterDatabaseHandlerTest
    {
        readonly IFilterDatabaseHandler _filterDatabaseHandler;

        public FilterDatabaseHandlerTest()
        {
            _filterDatabaseHandler = new FilterDatabaseHandler();
        }
        
            [Fact]
            public void FilterProductsBasedOnFilter()
            {
               var filter1 = new FilterModel
                {
                    TouchScreen = false
                };

                var flist = _filterDatabaseHandler.GetFilteredProducts(filter1);
                Assert.True(flist.Any());

            }
    }
}
