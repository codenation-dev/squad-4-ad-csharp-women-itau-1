using Microsoft.AspNetCore.Mvc;

namespace ProjetoPraticoCodenation.Extensions
{
    public static class UrlHelperExtentisions
    {
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return $"{scheme}://localhost:5001/api/v1/Auth/resetPassword?userId={userId}&code={code}";
        }
    }
}
