using System.Text.Json;

namespace Repository
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
