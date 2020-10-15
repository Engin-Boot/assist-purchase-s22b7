using DatabaseContractor;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DatabaseManager
{
    public class ProductContext : DbContext
    {
        readonly string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Products.db");

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={dbPath}");
    }

    public class SalesContext : DbContext
    {
        readonly string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Sales.db");

        public DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={dbPath}");
    }
}






