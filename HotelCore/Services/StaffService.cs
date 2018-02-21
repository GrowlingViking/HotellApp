using HotelCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace HotelCore.Services
{
    public class StaffService
    {
        private HotelModelCf dx;

        public StaffService(HotelModelCf ctx)
        {
            dx = ctx;
        }

        public List<Task> GetTasks(string taskType)
        {
            return dx.Tasks.Where(t => t.ServiceType == taskType).ToList();
        }

        public List<Task> GetAllTasks()
        {
            return dx.Tasks.Include(t => t.Notes).Include(t => t.Room).ToList();
        }

        public List<Note> GetNotes(int task)
        {
            return dx.Notes.Where(n => n.Task.Id == task).ToList();
        }

        public Task GetTask(int id)
        {
            return dx.Tasks.Where(t => t.Id == id).Single();
        }

        public void SetTaskStatus(int taskId, string newStatus)
        {
            var task = dx.Tasks.Where(t => t.Id == taskId).Single();
            task.Status = newStatus;
            dx.SaveChanges();
        }

        public void AddNoteToTask(int taskId, string note)
        {
            var task = dx.Tasks.Where(t => t.Id == taskId).Single();
            task.Notes.Add(new Note { Text = note });
            dx.SaveChanges();
        }
    }
}
