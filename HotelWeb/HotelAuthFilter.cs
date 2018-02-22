using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelWeb
{
    public class HotelAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        private SecurityManager securityManager;

        public HotelAuthFilter()
        {
            securityManager = new SecurityManager(new HotelCore.ServiceFactory());
        }

        public void OnAuthorization(AuthorizationContext context)
        {
            if (context.HttpContext.Session["loggedInUser"] == null)
            {
                RedirectToLogin(context);
            }
        }

        private void RedirectToLogin(AuthorizationContext context)
        {
            context.Result = new RedirectResult("/login");
        }
    }
}