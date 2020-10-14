using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssistPurchase.DatabaseContractor
{
    public class FilterJsonFormatter
    {
        [JsonPropertyName("UID")]
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<string> DisplayType { get; set; } = null;
        public IntLimits DisplaySize { get; set; }
        public DoubleLimits Weight { get; set; }
        public bool TouchScreen { get; set; }

        public class IntLimits
        {
            public int Max { get; set; }
            public int Min { get; set; }
        }

        public class DoubleLimits
        {
            public double Max { get; set; }
            public double Min { get; set; }
        }
    }

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
}
