using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseManager
{
    class DatabaseController
    {
        private ProductContext db = new ProductContext();
       // How to acces db file
        public void AddProductToDb(Product product)
        {
            Console.WriteLine("Inserting a new Product");
            db.Add(product);
            db.SaveChanges();
        }

        Product GetProductByNameFromDb()
        {
            // Read
            Console.WriteLine("Querying for a Product");
            var product = db.Products
                .OrderBy(b => b.DisplaySize)
                .First();
            return product;
        }

        Product GetProductByIdFromDb(string id, string type)
        {
            return (Product)db.Products
                 .Where(b => b.Id == id);
        }

        void UpdateProductInDb(Product product)
        {
            // Update
            Console.WriteLine("Updating the Product ");
            product.Id = "ChangedName";
            db.SaveChanges();
        }

        void RemoveProductFromDb(Product product)
        {
            // Delete
            Console.WriteLine("Delete the Product");
            db.Remove(product);
            db.SaveChanges();
        }
    }
}

