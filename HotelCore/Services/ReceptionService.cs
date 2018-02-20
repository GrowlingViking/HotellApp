using HotelCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Services
{
    public class ReceptionService
    {
        private HotelModelCf ctx;

        public ReceptionService(HotelModelCf ctx)
        {
            this.ctx = ctx;
        }

        public List<Reservation> GetReservations(bool active)
        {
            return ctx.Reservations.Where(res => !active || res.Room == null).ToList();
        }

        public List<Room> GetRooms()
        {
            return ctx.Rooms.Include(r => r.Type).ToList();
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

        public Reservation GetReservation(int id)
        {
            return ctx.Reservations.Where(res => res.Id == id).First();
        }
    }
}
