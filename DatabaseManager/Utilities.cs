using AssistPurchase.DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
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

        public static PropertyInfo[] GetProperties<T>() => typeof(T).GetProperties();

        //delegate(string s1, T1 obj1, List<T2> obj2) {
        public static Func<string, S, List<T>, List<T>> MethodCase<S,T>(string name)
        {
            Func<string, S, List<T>, List<T>> filterMethod;
            filterMethod = UnImplementedMethod;
            switch (name)
            {
                case "DisplayType":
                    filterMethod = SelectionByChoice;
                    break;
                case "DisplaySize": case "Weight":
                    filterMethod = SelectionByRange;
                    break;
                case "TouchScreen":
                    filterMethod = SelectionByBinary;
                    break;
            }

            return filterMethod;
                             
        }

        private static List<T> UnImplementedMethod<S,T>(string arg1, S arg2, List<T> arg3)
        {
            throw new NotImplementedException();
        }

        private static List<T> SelectionByBinary<S,T>(string arg1, S arg2, List<T> arg3)
        {
            throw new NotImplementedException();
        }

        private static List<T> SelectionByRange<S,T>(string arg1, S arg2, List<T> arg3)
        {
            throw new NotImplementedException();
        }

        private static List<T> SelectionByChoice<S,T>(string arg1, S arg2, List<T> arg3)
        {
            throw new NotImplementedException();
        }
        
    }
}
