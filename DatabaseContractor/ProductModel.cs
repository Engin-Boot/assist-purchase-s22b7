using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DatabaseContractor
{
    public class Product
    {
        [JsonPropertyName("UID")]
        public string Id { get; set; }
        public string Name { get; set; }
        public int DisplaySize { get; set; }
        public string DisplayType { get; set; }
        public double Weight { get; set; }
        public bool TouchScreen { get; set; }
    }

    public class ListOfProducts
    {
        public List<Product> Products { get; set; }
    }
}
