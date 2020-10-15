using DatabaseContractor;
using DatabaseManager.ProductDatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DatabaseManager
{
    class FilterDatabaseHandler:IFilterDatabaseHandler
    {
        public List<Product> GetProductsByFilter(FilterModel filterObj)
        {
            try
            {
                using ProductContext _db = new ProductContext();

                var Products = _db.Products.ToList();

                var properties = Utilities.GetProperties<FilterModel>();
                foreach (PropertyInfo prop in properties)
                {
                    if (Utilities.HasPropertyValue(prop, filterObj))
                    {
                        string PropertyName = prop.Name;
                        var method = Utilities.MethodCase<FilterModel, Product>(PropertyName);
                        Products = method(PropertyName, filterObj, Products);
                    }
                }
                return Products;
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                throw e;
            }
        }
    }
}
