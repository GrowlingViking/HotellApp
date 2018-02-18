using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public RoomType Type { get; set; }

        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
    }
}
