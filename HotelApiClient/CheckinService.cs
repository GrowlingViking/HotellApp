using HotelApiClient.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelApiClient
{
    public class CheckinService : ServiceBase
    {
        internal CheckinService(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        public IList<Reservation> ListPendingReservations()
        {
            throw new NotImplementedException();
        }

        public void CheckIn(int reservationId)
        {
            throw new NotImplementedException();
        }

        public void CheckOut(int reservationId)
        {
            throw new NotImplementedException();
        }
    }
}