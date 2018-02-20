using HotelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWeb.Controllers.Api
{
    public class TasksController : ApiController
    {
        private ServiceFactory serviceFactory = new ServiceFactory();

        [Route("api/tasks")]
        [HttpGet]
        public IHttpActionResult GetAllTasks()
        {
            var staffService = serviceFactory.GetStaffService();
            var tasks = staffService.GetAllTasks();

            return Ok(tasks);
        }


    }
}