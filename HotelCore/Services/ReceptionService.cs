using HotelCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Services
{

    public delegate void Del(object sender);

    public class ReceptionService
    {
        public event Del StateChanged;
        private HotelModelCf ctx;

        // Data

        public ReceptionService(HotelModelCf ctx)
        {
            this.ctx = ctx;
        }

        public List<Reservation> GetReservations(bool active)
        {
            return ctx.Reservations.Where(res => !active || res.Room == null || res.End > DateTime.Now).ToList();
        }

        public List<Room> GetRooms()
        {
            return ctx.Rooms.Include(r => r.Type).ToList();
        }

        public Room GetRoom(int nr)
        {
            return ctx.Rooms.Where(r => r.Nr == nr).First();
        }

        public List<Entities.Task> GetTasks(int roomId)
        {
            return ctx.Tasks.Where(t => t.Room.Id == roomId).OrderByDescending(t => t.Id).ToList();
        }

        public Entities.Task GetTask(int taskId)
        {
            return ctx.Tasks.Find(taskId);
        }

        public List<String> GetRoomTypes()
        {
            return ctx.RoomTypes.Select(rt => rt.Name).ToList();
        }

        public List<Room> GetReadyRooms(String roomType)
        {
            return ctx.Rooms.Where(r => r.Type.Name == roomType)
            .Where(r => r.Reservations.Where(res => res.End < DateTime.Now).Count() == 0)
            .Where(r => r.Tasks.Where(task => task.ServiceType == TaskTypes.Cleaning)
                .Where(task => task.Status == TaskStatus.In_progress || task.Status == TaskStatus.New).Count() == 0)
            .ToList();
        }

        public List<Note> GetNotes(int id)
        {
            return ctx.Notes.Where(n => n.Task.Id == id).ToList();
        }

        // Actions

        public bool CheckIn(int id, int roomNr)
        {
            Reservation res = ctx.Reservations.Where(r => r.Id == id).First();
            res.Room = ctx.Rooms.Where(r => r.Nr == roomNr).First();
            res.Start = DateTime.Now;
            return SaveChanges(1);
        }

        public bool CheckOut(int id)
        {
            Reservation res = ctx.Reservations.Where(r => r.Id == id).First();
            res.End = DateTime.Now;
            Entities.Task cleaning = new Entities.Task();
            cleaning.Room = res.Room;
            cleaning.ServiceType = TaskTypes.Cleaning;
            cleaning.Status = TaskStatus.New;
            ctx.Tasks.Add(cleaning);
            return SaveChanges(2);
        }

        public bool ModifyRes(int id, DateTime start, DateTime end, String type)
        {
            Reservation res = ctx.Reservations.Where(r => r.Id == id).First();
            res.Start = start;
            res.End = end;
            res.Type = ctx.RoomTypes.Where(t => t.Name == type).First();
            res.Room = null; // require checkin again
            return SaveChanges(1);
        }

        public bool DeleteRes(int id)
        {
            ctx.Reservations.Remove(ctx.Reservations.Where(r => r.Id == id).First());
            return SaveChanges(1);
        }

        public bool NewTask(int roomId, String taskType)
        {
            Entities.Task task = new Entities.Task();
            task.Room = ctx.Rooms.Where(r => r.Id == roomId).First();
            task.ServiceType = taskType;
            task.Status = TaskStatus.New;
            ctx.Tasks.Add(task);
            return SaveChanges(1);
        }

        public bool ModifyTask(int id, String type, String status)
        {
            Entities.Task task = ctx.Tasks.Find(id);
            task.ServiceType = type;
            task.Status = status;
            return SaveChanges(1);
        }

        public bool NewRoom(int nr, String type)
        {
            if (ctx.Rooms.Where(r => r.Nr == nr).Count() == 0)
            {
                Room room = new Room();
                room.Nr = nr;
                room.Type = ctx.RoomTypes.Where(t => t.Name == type).First();
                ctx.Rooms.Add(room);
                return SaveChanges(1);
            }
            return false;
        }

        public bool ModifyRoom(int id, int nr, String type)
        {
            Room room = ctx.Rooms.Find(id);
            room.Nr = nr;
            room.Type = ctx.RoomTypes.Where(t => t.Name == type).First();
            return SaveChanges(1);
        }

        public bool NewNote(int taskId, String text)
        {
            Note note = new Note();
            note.Task = ctx.Tasks.Find(taskId);
            note.Text = text;
            ctx.Notes.Add(note);
            return SaveChanges(1);
        }

        // private method that saves and fires statechanged event

        private bool SaveChanges(int expected)
        {
            int changed = ctx.SaveChanges();
            if (changed >= expected)
                StateChanged?.Invoke(this);
            return changed >= expected;
        }
    }
}
