using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApiContracts
{
    public class UserReservation
    {
        public int Id { get; set; }
        public RoomBookingParams BookingParams { get; set; }
    }
}
