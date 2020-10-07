using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistAPurchase.Utility;

namespace AssistAPurchase.Repository
{
    public interface IProductDataRepository
    {
        IEnumerable<Models.ProductDataModel> GetAllProducts(ITransactionManager manager);
        void AddNewProduct(Models.ProductDataModel newState, ITransactionManager manager);
        void UpdateProductInfo(string id, Models.ProductDataModel state, ITransactionManager manager);
        void RemoveProduct(string id, ITransactionManager manager);
    }
}
