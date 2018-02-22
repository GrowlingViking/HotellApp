using HotelCore;
using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWeb.Controllers.MVC
{
    [RoutePrefix("login")]
    public class LoginController : Controller
    {
        private ServiceFactory serviceFactory = new ServiceFactory();

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public ActionResult Postback(LoginDataModel loginData)
        {
            var security = new SecurityManager(serviceFactory);
            try
            {
                security.VerifyUserLogin(loginData.Username, loginData.Password);
                var signin = new SigninManager(HttpContext);
                signin.SignIn(loginData.Username);
            }
            catch (AuthorizationException)
            {
                ViewBag.Message = "Login failed";
                return View("index");
            }

            return Redirect("/");
        }
    }
}