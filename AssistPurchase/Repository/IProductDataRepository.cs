using System.Collections.Generic;

namespace AssistPurchase.Repository
{
    public interface IProductDataRepository
    {
        IEnumerable<Models.ProductDataModel> GetAllProducts();
        Models.ProductDataModel AddNewProduct(Models.ProductDataModel newState);
        Models.ProductDataModel GetProductById(string id);
        bool UpdateProductInfo(string id, Models.ProductDataModel state);
        void Remove(string id);
        //Sales Person Info
        IEnumerable<Models.SalesPersonDataModel> GetSalesPersonDetails();
        bool UpdateSalesPersonInfo(string uid, Models.SalesPersonDataModel state1);
    }
}
