using DatabaseContractor;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace DatabaseManager
{
    public class AssistPurchaseContext : DbContext
    {
        //readonly string dbPath = Path.Combine(
        //                   Directory.GetParent(
        //                 Directory.GetParent(
        //               Directory.GetParent(
        //             Environment.CurrentDirectory).ToString()).ToString()).ToString(),
        //           "AssistPurchaseDatabase.db");
        readonly string dbPath = @"URI=file:C:\Users\320105541\OneDrive - Philips\Desktop\assistPurchase\assist-purchase-s22b7\DatabaseManager\AssistPurchaseDatabase.db";

        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={dbPath}");
    }

}






