using HotelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWeb.Controllers.MVC
{
    public class IndexController : Controller
    {
        private ServiceFactory sf = new ServiceFactory();

        [Route("")]
        public ActionResult Index()
        {
            var roomCount = sf.GetReceptionService().GetRooms().Count();
            return View(roomCount);
        }
    }
}