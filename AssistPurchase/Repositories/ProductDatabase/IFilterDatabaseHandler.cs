using DatabaseContractor;
using System.Collections.Generic;

namespace AssistPurchase.Repositories.ProductDatabase
{
    
    public interface IFilterDatabaseHandler
    {
        IEnumerable<Product> GetFilteredProducts(FilterModel filterObj);
        IEnumerable<Product> GetFilteredProductsBySize(FilterModel filterObj);
        IEnumerable<Product> GetFilteredProductsByWeight(FilterModel filterObj);
        IEnumerable<Product> GetFilteredProductsByTouch(FilterModel filterObj);

    }
}
