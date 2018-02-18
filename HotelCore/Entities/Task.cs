using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelCore.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }

        public Room Room { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
