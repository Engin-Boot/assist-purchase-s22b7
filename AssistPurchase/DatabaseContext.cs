﻿using DatabaseContractor;
using Microsoft.EntityFrameworkCore;


namespace AssistPurchase
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesInfo> Sales{ get; set; }

    }
}
