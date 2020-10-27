using DatabaseContractor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
