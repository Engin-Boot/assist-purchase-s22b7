using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Repository
{
    public interface IProductDataRepository
    {
        IEnumerable<Models.ProductDataModel> GetAllProducts();
        void AddNewProduct(Models.ProductDataModel newState);
        void UpdateProductInfo(string mrn, Models.ProductDataModel state);
        void Remove(string mrn);
    }
}
