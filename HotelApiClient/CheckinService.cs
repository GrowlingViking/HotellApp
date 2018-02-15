using HotelApiContracts;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelApiClient
{
    /**
     * Service class intended to be used primerily by reception staff for checking in and checking
     * out customers.
     * */
    public class CheckinService : ServiceBase
    {
        internal CheckinService(string baseUrl, HttpClient client) : base(baseUrl, client)
        {
        }

        /**
         * List all reservations that are not yet checked in
         * */
        public IList<Reservation> ListPendingReservations()
        {
            throw new NotImplementedException();
        }

        /**
         * Check in a reservation
         * */
        public void CheckIn(int reservationId)
        {
            throw new NotImplementedException();
        }

        /**
         * Check out a reservation
         * */
        public void CheckOut(int reservationId)
        {
            throw new NotImplementedException();
        }
    }
}