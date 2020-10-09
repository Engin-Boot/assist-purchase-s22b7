using System;
using System.Linq;

namespace DatabaseManager
{
    class Program
    {
        static void Main()
        {
            using (var db = new ProductContext())
            {
                // Create
                Console.WriteLine("Inserting a new Product");
                db.Add(new Product
                {
                    Id = "Example1",
                    DisplaySize = 4,
                    DisplayType = "LCD",
                    Battery = true,
                    TouchScreen = true,
                    Weight = 1.5
                });
                db.Add(new Product
                {
                    Id = "Example2",
                    DisplaySize = 5,
                    DisplayType = "LED",
                    Battery = true,
                    TouchScreen = false,
                    Weight = 2
                });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a Product");
                var Product = db.Products
                    .OrderBy(b => b.DisplaySize)
                    .First();

                // Update
                Console.WriteLine("Updating the Product ");
                Product.Id = "ChangedName";
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the Product");
                db.Remove(Product);
                db.SaveChanges();
            }
        }
    }
}
