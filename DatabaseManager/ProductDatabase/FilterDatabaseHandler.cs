using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DatabaseManager
{
    public class FilterDatabaseHandler : IFilterDatabaseHandler
    {
        public IEnumerable<Product> GetFilteredProducts(FilterModel filterObj)

        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                var products = _db.Products.ToList();

                FilterAssist f = new FilterAssist();

                return f.FilterByTouchScreen(filterObj.TouchScreen,
                            f.FilterByDisplayType(filterObj.DisplayType,
                            f.FilterByWeight(filterObj.Weight,
                            f.FilterByDisplaySize(filterObj.DisplaySize, products))));
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                throw e;
            }
        }
    }
}
