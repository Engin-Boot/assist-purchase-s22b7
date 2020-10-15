using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace DatabaseManager.ProductDatabase
{
    class FilterDatabaseHandler:IFilterDatabaseHandler
    {
        public IEnumerable<Product> ProductFilter(FilterModel filterObj)

        {
            try
            {
                using ProductContext _db = new ProductContext();
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
