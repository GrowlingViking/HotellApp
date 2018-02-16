using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore
{
    public class CustomerService
    {
        private dat154_18_1Entities dx;

        public CustomerService(dat154_18_1Entities ctx)
        {
            dx = ctx;
        }

        public List<Reservation> GetReservations(String user)
        {
            return dx.Reservations.Where(x => x.User.UserName == user).ToList();
        }

        public bool IsRoomAvailable(RoomType roomType, DateTime from, DateTime to)
        {
            return true;
        }

        public Reservation MakeReservation(string userName, RoomType roomType, DateTime from, DateTime to)
        {
            var user = dx.Users.Where(u => u.UserName == userName).Single();

            var reservation = new Reservation();
            reservation.RoomType = roomType;
            reservation.Start = from;
            reservation.End = to;
            reservation.User = user;
            dx.Reservations.Add(reservation);
            dx.SaveChanges();

            return reservation;
        }
    }
}
