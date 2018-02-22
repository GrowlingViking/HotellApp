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
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public ActionResult Postback()
        {
            ViewBag.Message = "Login failed";
            return View("index");
        }
    }
}