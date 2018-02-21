using HotelCore;
using HotelCore.Entities;
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
            var tasks = GenerateTaskList(staffService.GetAllTasks());

            return Ok(tasks);
        }

        [Route("api/tasks/{id}/{newStatus}")]
        [HttpPut]
        public IHttpActionResult UpdateStatusOfTask([FromUri] int id, [FromUri] string newStatus)
        {
            string status;
            switch (newStatus)
            {
                case "inprogress":
                    status = TaskStatus.In_progress;
                    break;
                case "finished":
                    status = TaskStatus.Finished;
                    break;
                default:
                    return BadRequest("Status is not valid");
            }

            var staffService = serviceFactory.GetStaffService();
            staffService.SetTaskStatus(id, status);
            return Ok();
        }

        [Route("api/tasks/{id}/notes")]
        [HttpPost]
        public IHttpActionResult AddNoteToTask([FromUri] int id, [FromBody] TaskNoteModel note)
        {
            serviceFactory.GetStaffService().AddNoteToTask(id, note.Text);
            return Ok();
        }

        private IEnumerable<TaskModel> GenerateTaskList(IEnumerable<Task> tasks)
        {
            var tasksModel = new List<TaskModel>();
            foreach (var task in tasks)
            {
                var taskModel = new TaskModel
                {
                    ID = task.Id,
                    ServiceType = task.ServiceType,
                    Status = task.Status,
                    RoomNr = task.Room.Nr,
                    Notes = new List<string>()
                };
                foreach (var note in task.Notes)
                {
                    taskModel.Notes.Add(note.Text);
                }
                tasksModel.Add(taskModel);
            }
            return tasksModel;
        }
    }
}