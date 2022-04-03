using System.ComponentModel;

namespace CidadeAlta.Domain.Enums;

public static class EnumHelper
{
    public static string GetEnumDescription(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        if (fi == null)
            return string.Empty;
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 
            ? attributes[0].Description 
            : value.ToString();
    }
}