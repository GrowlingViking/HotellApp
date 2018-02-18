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

        public virtual Room Room { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
