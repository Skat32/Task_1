using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Logic
{
    public static class Expansions
    {
        public static Dictionary<string, int> GetForDropList<T>(this T enumValue) where T : Type
        {
            var arr = enumValue.GetEnumValues();
            var result = new Dictionary<string, int>();

            foreach (var o in arr)
            {
                var fieldInfo = enumValue.GetField(o.ToString() ?? enumValue.ToString());
                
                if (fieldInfo is null) return new Dictionary<string, int>();

                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)
                    .Where(x => x.GetType() == typeof(DescriptionAttribute))
                    .Select(x => (DescriptionAttribute) x);
                
                result.Add(attrs.First().Description, (int)o);
            }

            return result;
        }
    }
}