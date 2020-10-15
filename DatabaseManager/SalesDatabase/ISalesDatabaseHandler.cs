using DatabaseContractor;
using System.Collections.Generic;
using System.Net;

namespace DatabaseManager
{
    public interface ISalesDatabaseHandler
    {
        IEnumerable<Sales> GetAllSales();
        HttpStatusCode AddSalesToDb(Sales info);
        Sales GetSalesByCustomerNameFromDb(string CustomerName);
    }
}
