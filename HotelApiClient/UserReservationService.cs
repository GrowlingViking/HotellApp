using HotelApiClient.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<bool> IsRoomAvailable(RoomBookingParams searchParams)
        {
            var result = await client.PostAsJsonAsync(BuildFullUrl("/reservations/availability"), searchParams);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            else
            {
                throw new HttpRequestException("Error occurred when checking availability");
            }
        }

        /*
         * Make a reservation given constraints. Return the reservation.
         * */
        public async Task<UserReservation> MakeReservation(RoomBookingParams bookingParams)
        {
            var result = await client.PostAsJsonAsync(BuildFullUrl("/reservations"), bookingParams);
            result.EnsureSuccessStatusCode();

            UserReservation reservation = null;
            reservation = await result.Content.ReadAsAsync<UserReservation>();

            return reservation;
        }

        /*
         * List reservations for user
         * */
        public IList<UserReservation> ListUserReservations()
        {
            throw new NotImplementedException();
        }

        /*
         * Get information for a single user reservation
         * */
        public UserReservation GetUserReservation(int id)
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
