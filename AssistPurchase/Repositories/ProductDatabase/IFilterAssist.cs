using System.Collections.Generic;
using DatabaseContractor;

namespace AssistPurchase.Repositories.ProductDatabase
{
    public interface IFilterAssist
    { 
        IEnumerable<Product> FilterByTouchScreen(bool touchScreen, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByDisplayType(List<string> display, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByWeight(Limits weight, IEnumerable<Product> productList);
        IEnumerable<Product> FilterByDisplaySize(Limits screen, IEnumerable<Product> productList);
    }
}
