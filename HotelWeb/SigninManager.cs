using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWeb
{
    public class SigninManager
    {
        private HttpContextBase context;

        public SigninManager(HttpContextBase context)
        {
            this.context = context;
        }

        public void SignIn(string username)
        {
            context.Session["loggedInUser"] = username;
        }

        public void SignOut()
        {
            context.Session["loggedInUser"] = null;
        }

        public bool IsLoggedIn()
        {
            return context.Session["loggedInUser"] != null;
        }
    }
}