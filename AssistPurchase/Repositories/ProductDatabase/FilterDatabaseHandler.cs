using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AssistPurchase.Repositories.ProductDatabase
{
    public class FilterDatabaseHandler : IFilterDatabaseHandler
    {
        private readonly DatabaseContext _db;

        public FilterDatabaseHandler(DatabaseContext context)
        {
            this._db = context;
        }
        public IEnumerable<Product> GetFilteredProducts(FilterModel filterObj)

        {
            try
            {
                
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
