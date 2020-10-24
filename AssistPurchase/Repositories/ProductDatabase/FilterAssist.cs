using DatabaseContractor;
using DatabaseManager.ProductDatabase;
using System.Collections.Generic;
using System.Linq;

namespace AssistPurchase.Repositories.ProductDatabase
{
    public class FilterAssist : IFilterAssist
    {
        public IEnumerable<Product> FilterByTouchScreen(bool TouchScreen, IEnumerable<Product> productList)
        {
            if (!TouchScreen) return productList;
            return productList.Where(p => p.TouchScreen == true);
        }

        public IEnumerable<Product> FilterByDisplayType(List<string> display, IEnumerable<Product> productList)
        {
            if (display == null) return productList;
            return productList.Where(p => display.Contains(p.DisplayType));
        }

        public IEnumerable<Product> FilterByWeight(DoubleLimits weight, IEnumerable<Product> productList)
        {
            if (weight == null) return productList;
            return productList.Where(p => weight.Min < p.Weight && p.Weight < weight.Max);
        }

        public IEnumerable<Product> FilterByDisplaySize(IntLimits screen, IEnumerable<Product> productList)
        {
            if (screen == null) return productList;
            return productList.Where(p => screen.Min < p.Weight && p.Weight < screen.Max);
        }
    }
}
