using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiBackend
{
    public class HeaderAuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                if (!IsValid(context))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch (InvalidOperationException)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private static bool IsValid(AuthorizationFilterContext context)
        {
            return GetApiKey(context) == "secret"; // TODO: load from configuration
        }

        private static string GetApiKey(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["X-Api-Key"];
            return apiKey.First();
        }
    }
}
