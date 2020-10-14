using Microsoft.EntityFrameworkCore;
using AssistPurchase.DatabaseContractor;

namespace DatabaseManager
{
    public class ProductContext : DbContext
    {
        string dbFileName = "products";

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={dbFileName}.db");
    }
}






