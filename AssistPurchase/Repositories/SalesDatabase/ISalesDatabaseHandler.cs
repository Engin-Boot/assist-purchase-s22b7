using DatabaseContractor;
using System.Collections.Generic;
using System.Net;

namespace AssistPurchase.Repositories.SalesDatabase
{
    public interface ISalesDatabaseHandler
    {
        IEnumerable<SalesInfo> GetAllSales();
        HttpStatusCode AddSalesToDb(SalesInput info);
    }
}
