using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore
{
    public class RoomTypes
    {
        public static string Family { get { return "Family"; } }
    }

    public class TaskTypes
    {
        public static string Cleaning { get { return "Cleaning"; } }
    }

    public class TaskStatus
    {
        public static string New { get { return "New"; } }
        public static string In_progress { get { return "In progress"; } }
        public static string Finished { get { return "Finished"; } }
    }
}
