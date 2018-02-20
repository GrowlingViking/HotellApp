using HotelCore;
using HotelWeb.Models;
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

        [Route("api/tasks/{id}/{status}")]
        public IHttpActionResult UpdateStatusOfTask([FromUri] int id, [FromUri] string status)
        {
            var staffService = serviceFactory.GetStaffService();
            staffService.SetTaskStatus(id, status);
            return Ok();
        }

        [Route("api/tasks/{id}/notes")]
        public IHttpActionResult AddNoteToTask([FromUri] int id, [FromBody] TaskNoteModel note)
        {
            serviceFactory.GetStaffService().AddNoteToTask(id, note.Text);
            return Ok();
        }
    }
}