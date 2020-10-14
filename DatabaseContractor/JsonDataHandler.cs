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
        //Incoming request -> JSON body -> String (JsonString) -> Call Function
        public object DeserializeJson<T>(string jsonString)
        {
            object JsonClass = JsonSerializer.Deserialize<T>(jsonString);
            return JsonClass;
        }

        //Populated Class -> JsonString -> JSON in Controller API
        public string SerializeJson<T>(object obj)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
