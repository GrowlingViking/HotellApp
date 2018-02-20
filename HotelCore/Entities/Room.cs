using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelCore.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public RoomType Type { get; set; }
        public int Nr { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
