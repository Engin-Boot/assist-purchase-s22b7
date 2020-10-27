﻿using AssistPurchase.Repositories.ProductDatabase;
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
            var filter1 = new FilterModel
            {
                DisplayType = { "LCD" },
                DisplaySize = new Limits
                   { Max = "12",
                       Min = "0"
                    },
                Weight = new Limits
                {
                    Max = "5",
                    Min = "0"
                },
                TouchScreen = false
            };

            var flist = _filterDatabaseHandler.GetFilteredProductsByTouch(filter1);
            Assert.True(flist.Any());

        }
    }
}
