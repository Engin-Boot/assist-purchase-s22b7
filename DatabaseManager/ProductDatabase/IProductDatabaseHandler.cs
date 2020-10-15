using DatabaseContractor;
using System.Collections.Generic;
using System.Net;

namespace DatabaseManager.ProductDatabase
{
    interface IProductDatabaseHandler
    {
        List<Product> GetAllProducts();
        HttpStatusCode AddProductToDb(Product product);
        Product GetProductByNameFromDb(string name);
        Product GetProductByIdFromDb(string id);
        HttpStatusCode UpdateProductInDb(Product product);
        HttpStatusCode RemoveProductFromDb(string id);
    }
}
