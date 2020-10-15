using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManager.ProductDatabase
{
    interface IFilterDatabaseHandler
    {
        List<Product> GetProductsByFilter(FilterModel filterObj);
    }
}
