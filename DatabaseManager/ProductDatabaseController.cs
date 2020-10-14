using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssistPurchase.DatabaseContractor;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManager
{
    class ProductDatabaseController
    {
        readonly ProductContext _db = new ProductContext();

        public List<Product> GetAllProducts() => _db.Products.ToList();
        
        public void AddProductToDb( Product product)
        {        
            _db.Add(product);
            _db.SaveChanges();
        }

        public Product GetProductByNameFromDb(string name) => _db.Products
                 .Where(b => b.Name == name).FirstOrDefault();

        public Product GetProductByIdFromDb(string id) => GetByID(id);

        private Product GetByID(string id) => _db.Products.Find(id);
                             
        public void UpdateProductInDb( Product product)
        {
            var dbProduct = GetByID(product.Id);
            var properties = Utilities.GetProperties<Product>();
            
            foreach (var prop in properties)
            {
                if (Utilities.HasPropertyValue(prop, product))
                    prop.SetValue(dbProduct, prop.GetValue(product, null));
            }

            _db.Remove(_db.Products
                 .Where(b => b.Id == product.Id));
            _db.Add(dbProduct);

            _db.SaveChanges();
        }

        public void RemoveProductFromDb(string id)
        {
            _db.Remove(_db.Products
                .Where(b => b.Id == id));
            _db.SaveChanges();
        }
    }
}
