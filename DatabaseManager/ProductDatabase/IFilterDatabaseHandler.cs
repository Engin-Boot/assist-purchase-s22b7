using DatabaseContractor;
using System.Collections.Generic;

namespace DatabaseManager
{
    public interface IFilterDatabaseHandler
    {
        IEnumerable<Product> GetFilteredProducts(FilterModel filterObj);
    }
}
