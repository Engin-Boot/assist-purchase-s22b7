using System;
using Microsoft.EntityFrameworkCore;
using DatabaseContractor;
using DatabaseContext = AssistPurchase.DatabaseContext;

namespace AssistPurchaseTest.ApiControllerTest
{
    public class InMemoryContext : IDisposable
    {
        protected readonly DatabaseContext Context;

        protected InMemoryContext()
        {
            var option = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase(
                databaseName: Guid.NewGuid().ToString()).Options;
            Context = new DatabaseContext(option);
            Context.Database.EnsureCreated();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var p1 = new Product()
            {
                Id = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true
            };
            Context.Add(p1);
            var testItem = new Product()
            {
                Id = "ADT100",
                Name = "IntelliVue X3",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true
            };
            Context.Add(testItem);
            var s1 = new SalesInfo()
            {
                CustomerName = "tom",
                EmailId = "tom123@gmail.com",
                Description = "Message",
            };
            Context.Add(s1);

            var info = new SalesInfo()
            {
                CustomerName = "Subject24",
                EmailId = "Example4@gmail.com",
                Description = "Message",

            };
    
        

            Context.Add(info);
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
