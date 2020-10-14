using System.Collections.Generic;
using System.Reflection;
using AssistPurchase.DatabaseContractor;

namespace DatabaseManager
{
    class FilterDatabaseController
    {
        readonly ProductContext _db = new ProductContext();
        public PropertyInfo[] getProperties<T>()
        {
            return typeof(T).GetProperties();
        }

        public void getProductsByFilter(FilterJsonFormatter filterObj)
        {
            
        }
    }
}
