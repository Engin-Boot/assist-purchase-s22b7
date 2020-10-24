using DatabaseContractor;
using System.Collections.Generic;

namespace AssistPurchase.Repositories.ProductDatabase
{
    public interface IFilterDatabaseHandler
    {
        IEnumerable<Product> GetFilteredProducts(FilterModel filterObj,string type);
    }
}
