using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseManager
{
    class DatabaseController
    {
        private ProductContext db = new ProductContext();

        Product obj1 = new Product
            {
                Id = "PDC105",
                Name = "Example",
                DisplaySize = 5,
                DisplayType = "LED",
                TouchScreen = false,
                Weight = 2
            };

        void AddProductToDb(Product product)
        {
            // Create
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

        Product GetProductByIdFromDb(string id)
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
