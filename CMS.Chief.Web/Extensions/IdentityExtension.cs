using System;
using System.Security.Claims;
using System.Security.Principal;

namespace CMS.Chief.Web.Extensions
{
    public static class IdentityExtension
    {
        public static int GetId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            var value = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Convert.ToInt32(value);
        }

        public static string GetRegion(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            var value = claimsIdentity.FindFirst("Region").Value;

            return value;
        }
    }
}