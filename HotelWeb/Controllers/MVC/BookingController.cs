using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWeb.Controllers.MVC
{
    [HotelAuthFilter]
    [RoutePrefix("booking")]
    public class BookingController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}