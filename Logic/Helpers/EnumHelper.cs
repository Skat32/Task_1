using System.ComponentModel;

namespace Logic.Helpers
{
    public static class EnumHelper
    {
        public static string DescriptionAttr<T>(this T source)
        {
            var field = source.GetType().GetField(source.ToString() ?? string.Empty);

            if (field is null) return string.Empty;
            
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}