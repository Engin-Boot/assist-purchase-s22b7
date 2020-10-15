using System.Reflection;

namespace DatabaseManager
{
    public class Utilities
    {
        public static bool HasPropertyValue(PropertyInfo prop, object T)
        {
            var y = prop.GetValue(T, null);
            var hasValue = y != null && !string.IsNullOrWhiteSpace(y.ToString());
            return hasValue;
        }

        public static PropertyInfo[] GetProperties<T>() => typeof(T).GetProperties();
    }
}
