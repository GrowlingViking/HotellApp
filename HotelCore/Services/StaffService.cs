using HotelCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Note> GetNotes(int task)
        {
            return dx.Notes.Where(n => n.Task.Id == task).ToList();
        }

        public Task GetTask(int id)
        {
            return dx.Tasks.Where(t => t.Id == id).Single();
        }
    }
}
