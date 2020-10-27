using DatabaseContractor;
using Microsoft.EntityFrameworkCore;


namespace AssistPurchase
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesInfo> Sales{ get; set; }

    }
}
