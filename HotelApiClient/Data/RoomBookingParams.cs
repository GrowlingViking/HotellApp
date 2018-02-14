using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApiClient.Data
{
    public class RoomBookingParams
    {
        public int NumerOfBeds { get; set; }
        public RoomKind RoomKind { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
