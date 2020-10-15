using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace DatabaseManager
{
    public class SalesDatabaseHandler : ISalesDatabaseHandler
    {
        public IEnumerable<Sales> GetAllSales()
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                return _db.Sales.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public HttpStatusCode AddSalesToDb(Sales info)
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                if (string.IsNullOrEmpty(info.CustomerName))
                    return HttpStatusCode.BadRequest;

                _db.AddAsync(info);
                _db.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                return HttpStatusCode.InternalServerError;
            }
        }

        public Sales GetSalesByCustomerNameFromDb(string CustomerName)
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                return _db.Sales
                 .Where(b => b.CustomerName == CustomerName).FirstOrDefault();
            }
            catch (Exception e) { throw e; }
        }

    }
}
