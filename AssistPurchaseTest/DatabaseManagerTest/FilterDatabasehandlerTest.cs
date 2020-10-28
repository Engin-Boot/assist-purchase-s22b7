
using AssistPurchase.Repositories.ProductDatabase;
using DatabaseContractor;
using System.Collections.Generic;
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
           
            var filter1 = new FilterModel
            {

                TouchScreen = true

            };

            var fList = _filterDatabaseHandler.GetFilteredProductsByTouch(filter1);
            Assert.True(fList.Any());

        }

        [Fact]
        public void FilterProductsBasedOnFilterTouchFalse()
        {

            var filter1 = new FilterModel
            {

                TouchScreen = false

            };

            var fList = _filterDatabaseHandler.GetFilteredProductsByTouch(filter1);
            Assert.True(fList.Any());

        }

        [Fact]
        public void FilterProductsBasedOnFilterType()
        {

            var filter1 = new FilterModel
            {

                DisplayType = new List<string> { "LCC" }
             };

            var fList = _filterDatabaseHandler.GetFilteredProducts(filter1);
            Assert.True(fList.Any());

        }

        [Fact]
        public void FilterProductsBasedOnFilterSize()
        {

            var filter1 = new FilterModel
            {

                DisplaySize = new Limits{ Max = "25", Min = "0" }
                
            };
            var fList = _filterDatabaseHandler.GetFilteredProductsBySize(filter1);
            Assert.True(fList.Any());

        }

        [Fact]
        public void FilterProductsBasedOnFilterWeight()
        {

            var filter1 = new FilterModel
            {

                Weight = new Limits { Max = "25", Min = "0" }

            };

            var fList = _filterDatabaseHandler.GetFilteredProductsByWeight(filter1);
            Assert.True(fList.Any());

        }


    }
}
