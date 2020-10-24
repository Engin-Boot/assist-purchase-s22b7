using DatabaseContractor;
using System.Collections.Generic;

namespace DatabaseManager.ProductDatabase
{
    public interface IFilterAssist
    {
        IEnumerable<Product> FilterByTouchScreen(bool TouchScreen, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByDisplayType(List<string> display, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByWeight(DoubleLimits weight, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByDisplaySize(IntLimits screen, IEnumerable<Product> productList);
    }
}
