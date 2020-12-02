using CMS.Core.Domain;

namespace CMS.Chief.Web.Extensions
{
    public static class EnumExtension
    {
        public static string ToType(this Type source)
        {
            return source switch
            {
                Type.Read => "Okuma",
                Type.Payment => "Ödeme",
                _ => null,
            };
        }
    }
}