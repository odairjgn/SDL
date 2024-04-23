using System.ComponentModel;
using System.Reflection;

namespace SDL.SpotifyClient.Extensions
{
    public static class EnumExtensions
    {
        public static string? ToDescription(this Enum element)
        {
            var attrib = element.GetAttribute<DescriptionAttribute>();
            return attrib?.Description;
        }

        public static TAtt? GetAttribute<TAtt>(this Enum element)
            where TAtt : Attribute
        {
            var fieldInfo = element.GetType().GetField(element.ToString());
            return fieldInfo?.GetCustomAttribute<TAtt>();
        }
    }
}
