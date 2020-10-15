using DatabaseContractor;
using System.Collections.Generic;

namespace DatabaseManager.ProductDatabase
{
    public interface IFilterDatabaseHandler
    {
        IEnumerable<Product> GetFilteredProducts(FilterModel filterObj);
    }
}
