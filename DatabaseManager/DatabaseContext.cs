using DatabaseContractor;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DatabaseManager
{
    public class AssistPurchaseContext : DbContext
    {
        readonly string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "AssistPurchase.db");

        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={dbPath}");
    }

}






