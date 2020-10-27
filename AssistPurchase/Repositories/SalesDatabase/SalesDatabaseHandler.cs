using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;

namespace AssistPurchase.Repositories.SalesDatabase
{
    [ExcludeFromCodeCoverage]
    public class SalesDatabaseHandler : ISalesDatabaseHandler
    {
        private readonly DatabaseContext _db;

        public SalesDatabaseHandler(DatabaseContext context)
        {
            _db = context;
        }
        public IEnumerable<SalesInfo> GetAllSales()
        {
            try
            {
                
                return _db.Sales.ToList();
            }
            catch (Exception) { return null; }
        }

        public HttpStatusCode AddSalesToDb(SalesInput info)
        {
            var dInfo = _db.Sales.FirstOrDefault(b => b.CustomerName == info.CustomerName);
            try
            {
                if (dInfo != null)
                    return HttpStatusCode.Unauthorized;

                var salesInfo = new SalesInfo
                {
                    CustomerName = info.CustomerName,
                    EmailId = info.EmailId,
                    Description = string.Join(", ", info.Description.Select(c => c.ToString()).ToArray())
                };
                _db.Add(salesInfo);
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
