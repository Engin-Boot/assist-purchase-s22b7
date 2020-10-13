using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Repository
{
    public interface IUserDataRepository
    {
        IEnumerable<Models.ProductDataModel> GetAllProducts();
        IEnumerable<Models.ProductDataModel> GetProductByWearability(string wearable);
        IEnumerable<Models.ProductDataModel> GetProductByPrice(string price);
        Models.ProductDataModel AddNewProduct(Models.ProductDataModel newState);
        Models.ProductDataModel GetProductById(string id);
        //bool UpdateProductInfo(string id, Models.ProductDataModel state);
        //void Remove(string id);
    }
}
