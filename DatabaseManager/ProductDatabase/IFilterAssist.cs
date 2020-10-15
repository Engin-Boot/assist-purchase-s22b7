using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManager.ProductDatabase
{
    public interface IFilterAssist
    {
        IEnumerable<Product> FilterByTouchScreen(bool TouchScreen, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByDisplayType(List<string> display, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByWeight(FilterModel.DoubleLimits weight, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByDisplaySize(FilterModel.IntLimits screen, IEnumerable<Product> productList);
    }
}
