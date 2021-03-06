﻿
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace DatabaseContractor
{
    [ExcludeFromCodeCoverage]
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
    [ExcludeFromCodeCoverage]
    public class ProductInput
    {
        [JsonPropertyName("UID")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string DisplaySize { get; set; }

        public string DisplayType { get; set; }

        public string Weight { get; set; }

        public bool TouchScreen { get; set; }
    }

    
}
