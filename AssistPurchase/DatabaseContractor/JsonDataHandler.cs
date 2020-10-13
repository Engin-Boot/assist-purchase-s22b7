using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssistPurchase.DatabaseContractor
{
    public class JsonDataHandler
    {
      
        public object DeserializeJson<T>(string jsonString)
        {
            object JsonClass = JsonSerializer.Deserialize<T>(jsonString);
            return JsonClass;
        }

        public string SerializeJson<T>(object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
