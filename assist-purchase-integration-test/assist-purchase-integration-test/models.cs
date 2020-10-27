using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace assist_purchase_integration_test
{
    class models
    {
    }
    public class ProductInput
    {
        
        public string UID { get; set; }

        public string Name { get; set; }

        public string DisplaySize { get; set; }

        public string DisplayType { get; set; }

        public string Weight { get; set; }

        public bool TouchScreen { get; set; }
    }

    public class ListOfProducts
    {
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public int DisplaySize { get; set; }

        public string DisplayType { get; set; }

        public double Weight { get; set; }

        public bool TouchScreen { get; set; }
    }

    public class Sales
    {
       
        public string CustomerName { get; set; }

        public string EmailId { get; set; }
        public string Description { get; set; }
    }
}
