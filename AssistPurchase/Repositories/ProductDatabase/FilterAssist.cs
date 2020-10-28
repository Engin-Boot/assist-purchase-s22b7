using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssistPurchase.Repositories.ProductDatabase
{
    public class FilterAssist
    {
        public IEnumerable<Product> FilterByTouchScreen(bool touchScreen, IEnumerable<Product> productList)
        {
            if (!touchScreen) return productList;
            return productList.Where(p => p.TouchScreen);
        }

        public IEnumerable<Product> FilterByDisplayType(List<string> display, IEnumerable<Product> productList)
        {
            if (display == null) return productList;
            IEnumerable<Product> list= productList.Where(p => display.Contains(p.DisplayType));
            return list;
        }

        public IEnumerable<Product> FilterByWeight(Limits weight, IEnumerable<Product> productList)
        {
            if (weight == null) return productList;


            return productList.Where(p => Convert.ToDouble(weight.Min) <= p.Weight && Convert.ToDouble(weight.Max) >= p.Weight);
        }

        public IEnumerable<Product> FilterByDisplaySize(Limits screen, IEnumerable<Product> productList)
        {
            if (screen == null) return productList;
             
            IEnumerable<Product> list= productList.Where(p => Convert.ToInt32(screen.Min) <= p.DisplaySize && p.DisplaySize <= Convert.ToInt32(screen.Max));

            return list;
        }
    }
}
