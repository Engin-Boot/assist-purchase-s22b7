using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseContractor
{
    public class Product
    {
        [JsonPropertyName("UID")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("displaySize")]
        public int DisplaySize { get; set; }
        [JsonPropertyName("displayType")]
        public string DisplayType { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonPropertyName("touchScreen")]
        public bool TouchScreen { get; set; }
    }

    public class ListOfProducts
    {
        public List<Product> Products { get; set; }
    }
}
