using DatabaseContractor;
using System.Collections.Generic;

namespace DatabaseManager.ProductDatabase
{
    interface IFilterDatabaseHandler
    {
        IEnumerable<Product> ProductFilter(FilterModel filterObj);
    }
}
