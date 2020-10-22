using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace AssistPurchase.Repositories.SalesDatabase
{
    public class SalesDatabaseHandler : ISalesDatabaseHandler
    {
        private readonly DatabaseContext _db;

        public SalesDatabaseHandler(DatabaseContext context)
        {
            this._db = context;
        }
        public IEnumerable<Sales> GetAllSales()
        {
            try
            {
                
                return _db.Sales.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public HttpStatusCode AddSalesToDb(Sales info)
        {
            try
            {
                

                var Dinfo = _db.Sales.Where(b => b.CustomerName == info.CustomerName).FirstOrDefault();
                if (Dinfo != null)
                    return HttpStatusCode.Unauthorized;

                _db.Add(info);
                _db.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Trace.TraceInformation(e.Message);
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
