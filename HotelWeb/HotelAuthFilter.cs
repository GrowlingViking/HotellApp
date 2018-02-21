using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWeb
{
    public class HotelAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        private SecurityManager securityManager;

        public HotelAuthFilter()
        {
            securityManager = new SecurityManager(new HotelCore.ServiceFactory());
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}