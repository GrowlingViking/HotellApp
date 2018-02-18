using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Task Task { get; set; }
    }
}
