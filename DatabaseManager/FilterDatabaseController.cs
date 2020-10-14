using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AssistPurchase.DatabaseContractor;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManager
{
    class FilterDatabaseController
    {
        readonly ProductContext _db = new ProductContext();

        public List<Product> GetProductsByFilter(FilterJsonFormatter filterObj)
        {
            var Products = _db.Products.ToList();
            var properties = typeof(FilterJsonFormatter).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (Utilities.HasPropertyValue(prop, filterObj))
                {
                    string PropertyName = prop.Name;
                    var method = Utilities.MethodCase<FilterJsonFormatter,Product>(PropertyName);
                    Products = method(PropertyName,filterObj,Products);
                }
            }
            return Products;
        }
        
        public void GetFilterOptions()
        {


        }
    }
}
