using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Repository
{
    public interface IProductDataRepository
    {
        IEnumerable<Models.ProductDataModel> GetAllProducts();
        bool AddNewProduct(Models.ProductDataModel newState);
        bool UpdateProductInfo(string id, Models.ProductDataModel state);
        bool Remove(string id);
    }
}
