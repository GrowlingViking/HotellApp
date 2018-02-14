using HotelApiClient.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HotelApiClient
{
    /*
     * Service class implementing reservation creation, search and management. These are all operations
     * meant to be run on behalf of a single user.
     * */
    public class UserReservationService : ServiceBase
    {
        internal UserReservationService(string baseUrl, HttpClient client) : base(baseUrl, client)
        { }

        /**
         * Check if a room is available given constraints. Returns true or false.
         * */
        public bool IsRoomAvailable(RoomBookingParams searchParams)
        {
            throw new NotImplementedException();
        }

        /*
         * Make a reservation given constraints. Return the reservation.
         * */
        public UserRservation MakeReservation(RoomBookingParams bookingParams)
        {
            throw new NotImplementedException();
        }

        /*
         * List reservations for user
         * */
        public IList<UserRservation> ListUserReservations()
        {
            throw new NotImplementedException();
        }

        /*
         * Get information for a single user reservation
         * */
        public UserRservation GetUserReservation(int id)
        {
            throw new NotImplementedException();
        }

        /*
         * Delete a user reservation
         * */
        public void DeleteUserReservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
