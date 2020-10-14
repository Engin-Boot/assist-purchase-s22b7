using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
    }
}
