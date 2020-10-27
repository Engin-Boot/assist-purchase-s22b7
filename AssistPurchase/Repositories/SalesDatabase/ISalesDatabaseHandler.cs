using DatabaseContractor;
using System.Collections.Generic;
using System.Net;

namespace AssistPurchase.Repositories.SalesDatabase
{
    public interface ISalesDatabaseHandler
    {
        IEnumerable<Sales> GetAllSales();
        HttpStatusCode AddSalesToDb(SalesInput info);
    }
}
