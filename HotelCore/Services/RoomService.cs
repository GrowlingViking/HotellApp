using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Services
{
    public class RoomService
    {
        private dat154_18_1Entities dx;

        public RoomService(dat154_18_1Entities ctx)
        {
            dx = ctx;
        }

        public RoomType GetRoomType(string type)
        {
            return dx.RoomTypes.Where(rt => rt.Name == type).Single();
        }
    }
}
