using DatabaseContractor;
using System.Collections.Generic;
using System.Net;

namespace DatabaseManager.SalesDatabase
{
    interface ISalesDatabaseHandler
    {
        List<Sales> GetAllSales();
        HttpStatusCode AddSalesToDb(Sales info);
        Sales GetSalesByCustomerNameFromDb(string CustomerName)
    }
}
