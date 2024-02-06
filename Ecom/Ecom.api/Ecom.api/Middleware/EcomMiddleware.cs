using Ecom.DataAccess.DBCredentials;
using System.Security.Claims;

namespace Ecom.api.Middleware
{
   
    public class EcomMiddleware
    {
        private readonly RequestDelegate _next;

        public EcomMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApplicationCredentials applicationCredentials)
        {
            //if (context.User.Identity.IsAuthenticated)
            //{
            //string emailId = GetClaimUserName(context);
            //if (emailId != null)
            //{
            //    await applicationCredentials.SetAppDomain();
            //    var userProfile = await userRepository.GetUserData(emailId);
            //    if (userProfile != null)
            //    {
            //        CurrentUser.LoggedInUserEmail = userProfile.RoleName;
            //    }
            //}

            await applicationCredentials.SetAppDomain();
            await _next(context);
            //}
        }

        private string? GetClaimUserName(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.User.Identity.Name))

                if (context.User.Identity.Name != null)
                {
                    return context.User.FindFirst(ClaimTypes.Email) != null ? context.User.FindFirst(ClaimTypes.Email)?.Value?.ToLower()
                        : context.User.FindFirst(ClaimTypes.Upn)?.Value?.ToLower();
                }

            return string.Empty;
        }
    }
}
