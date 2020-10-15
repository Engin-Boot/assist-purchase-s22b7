using DatabaseContractor;
using System.Collections.Generic;
using System.Net;

namespace DatabaseManager
{
    public interface IProductDatabaseHandler
    {
        IEnumerable<Product> GetAllProductsFromDb();
        HttpStatusCode AddProductToDb(Product product);
        Product GetProductByNameFromDb(string name);
        Product GetProductByIdFromDb(string id);
        HttpStatusCode UpdateProductInDb(Product product);
        HttpStatusCode RemoveProductFromDb(string id);
    }
}
