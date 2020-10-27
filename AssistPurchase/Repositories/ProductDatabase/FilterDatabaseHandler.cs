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
            //try
            {
                
                var products = _db.Products.ToList();

                FilterAssist f = new FilterAssist();
                return f.FilterByDisplayType(filterObj.DisplayType,products);
}
            //catch (Exception e)
            //{
            //    Trace.TraceInformation(e.Message);
            //    throw e;
            //}
        }


        public IEnumerable<Product> GetFilteredProductsBySize(FilterModel filterObj)

        {
            //try
            {

                FilterAssist f = new FilterAssist();
                return f.FilterByDisplaySize(filterObj.DisplaySize, GetFilteredProducts(filterObj));

            }
            //catch (Exception e)
            //{
            //    Trace.TraceInformation(e.Message);
            //    throw e;
            //}
        }

        public IEnumerable<Product> GetFilteredProductsByWeight(FilterModel filterObj)

        {
            //try
            {

                FilterAssist f = new FilterAssist();
                return f.FilterByWeight(filterObj.Weight,GetFilteredProductsBySize(filterObj));

            }
            //catch (Exception e)
            //{
            //    Trace.TraceInformation(e.Message);
            //    throw e;
            //}
        }

        public IEnumerable<Product> GetFilteredProductsByTouch(FilterModel filterObj)

        {
            //try
            {

                
                FilterAssist f = new FilterAssist();
                return f.FilterByTouchScreen(filterObj.TouchScreen, GetFilteredProductsByWeight(filterObj));

            }
            //catch (Exception e)
            //{
            //    Trace.TraceInformation(e.Message);
            //    throw e;
            //}
        }
       
                
    }
}
