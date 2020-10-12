using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManager
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=products.db");
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int DisplaySize { get; set; }
        public string DisplayType { get; set; }
        public double Weight { get; set; }
        public bool TouchScreen { get; set; }
    }
}






