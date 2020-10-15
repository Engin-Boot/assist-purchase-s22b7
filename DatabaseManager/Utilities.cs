using System;
using System.Collections.Generic;
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

        public static Func<string, S, List<T>, List<T>> MethodCase<S, T>(string name)
        {
            Func<string, S, List<T>, List<T>> filterMethod;
            filterMethod = UnImplementedMethod;
            switch (name)
            {
                case "DisplayType":
                    filterMethod = SelectionByChoice;
                    break;
                case "DisplaySize":
                case "Weight":
                    filterMethod = SelectionByRange;
                    break;
                case "TouchScreen":
                    filterMethod = SelectionByBinary;
                    break;
                default: filterMethod = UnImplementedMethod;
                    break;
            }
            return filterMethod;

        }

        private static List<T> UnImplementedMethod<S, T>(string arg1, S arg2, List<T> arg3) =>
            throw new NotImplementedException();

        private static List<T> SelectionByBinary<S, T>(string name, S filterObj, List<T> products)
        {
            var SpropertyValue = typeof(S).GetProperty(name).GetValue(filterObj, null);
            var Tproperty = typeof(T).GetProperty(name);
            foreach (var p in products)
            {
                if ( SpropertyValue != Tproperty.GetValue(p, null))
                {
                    products.Remove(p);
                }
            }
            return products;
        }
        private static List<T> SelectionByRange<S, T>(string name, S filterObj, List<T> products)
        {
            var Tproperty = typeof(T).GetProperty(name);
            var SpropertyValue = typeof(S).GetProperty(name).GetValue(filterObj, null);
            var LimitType = SpropertyValue.GetType();
            var LimitMaxValue = LimitType.GetProperty("Max").GetValue(SpropertyValue,null);
            var LimitMinValue = LimitType.GetProperty("Min").GetValue(SpropertyValue,null);
           // var LimitPropertyType = typeof(LimitType.GetProperty("Max").PropertyType);
           /*
            foreach (var p in products)
            {
                if (LimitMinValue < Tproperty.GetValue(p, null) < LimitMaxValue)
                {

                }
            }
           */
            throw new NotImplementedException();
        }

        private static List<T> SelectionByChoice<S, T>(string name, S filterObj, List<T> products)
        {
            throw new NotImplementedException();
        }

    }
}
