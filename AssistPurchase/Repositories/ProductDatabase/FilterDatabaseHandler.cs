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
        public IEnumerable<Product> GetFilteredProducts(FilterModel filterObj,string type)

        {
            try
            {
                
                var products = _db.Products.ToList();

                FilterAssist f = new FilterAssist();
                if(type=="DisplayType")
                    return f.FilterByDisplayType(filterObj.DisplayType,products);

                if (type=="DisplaySize")
                    return f.FilterByDisplaySize(filterObj.DisplaySize, f.FilterByDisplayType(filterObj.DisplayType, products));

                if (type == "Weight")
                    return f.FilterByWeight(filterObj.Weight, f.FilterByDisplaySize(filterObj.DisplaySize, f.FilterByDisplayType(filterObj.DisplayType, products)));

                return f.FilterByTouchScreen(filterObj.TouchScreen, f.FilterByWeight(filterObj.Weight, f.FilterByDisplaySize(filterObj.DisplaySize, f.FilterByDisplayType(filterObj.DisplayType, products))));
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                throw e;
            }
        }
    }
}
