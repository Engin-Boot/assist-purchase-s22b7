using System.Linq;
using System.Reflection;
using AssistPurchase.DatabaseContractor;

namespace DatabaseManager
{
    class ProductDatabaseController
    {
        readonly ProductContext _db = new ProductContext();

        public void AddProductToDb( Product product)
        {        
            _db.Add(product);
            _db.SaveChanges();
        }

        public Product GetProductByNameFromDb(string name) => (Product)_db.Products
                 .Where(b => b.Name == name);

        public Product GetProductByIdFromDb(string id) => (Product)GetByID(id);

        private IQueryable<Product> GetByID(string id) => _db.Products
                             .Where(b => b.Id == id);
    

        public void UpdateProductInDb( Product product)
        {
            Product dbProduct = (Product)GetByID(product.Id);
            var properties = typeof(Product).GetProperties();
            
            foreach (PropertyInfo prop in properties)
            {
                if (Utilities.HasPropertyValue(prop, product))
                    prop.SetValue(dbProduct, prop.GetValue(product, null));
            }

            _db.Remove(GetByID(product.Id));
            _db.Add(dbProduct);

            _db.SaveChanges();
        }

        public void RemoveProductFromDb(string id)
        {
            _db.Remove(GetByID(id));
            _db.SaveChanges();
        }
    }
}

