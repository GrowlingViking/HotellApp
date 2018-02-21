using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWeb.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }
        public int RoomNr { get; set; }
        public List<string> Notes { get; set; }
    }
}