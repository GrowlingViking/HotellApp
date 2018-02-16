using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore
{
    class ReseptionService
    {
        private dat154_18_1Entities dx;

        public ReseptionService()
        {
            dx = new dat154_18_1Entities();
        }

        public List<Reservation> GetReservations(bool active)
        {
            return dx.Reservations.Where(res => !active || res.Room == null).ToList();
        }

        public List<Room> GetReadyRooms(String roomType)
        {
            return dx.Rooms.Where(r => r.RoomType.Name == roomType 
            && r.Reservations.Where(res => res.End < DateTime.Now).Count() == 0 
            && true).ToList(); //todo
        }
    }
}
