using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApiClient.Data
{
    public class UserRservation
    {
        public int Id { get; set; }
        public RoomBookingParams BookingParams { get; set; }
    }
}
