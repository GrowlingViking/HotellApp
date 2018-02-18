using HotelCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Services
{
    public class RoomService
    {
        private HotelModelCf dx;

        public RoomService(HotelModelCf ctx)
        {
            dx = ctx;
        }

        public RoomType GetRoomType(string type)
        {
            return dx.RoomTypes.Where(rt => rt.Name == type).Single();
        }
    }
}
