using System.Collections.Generic;


namespace AssistPurchase.Repository
{
    public interface IUserDataRepository
    {
        IEnumerable<Models.ProductDataModel> GetAllProducts();
        IEnumerable<Models.ProductDataModel> GetProductByWearability(string wearable);
        IEnumerable<Models.ProductDataModel> GetProductByPrice(string price);
        Models.ProductDataModel AddNewProduct(Models.ProductDataModel newState);
        Models.ProductDataModel GetProductById(string id);
    }
}
