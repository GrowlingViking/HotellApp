using System;
using System.Net.Http;

namespace HotelApiClient
{
    public class ApiClient
    {
        private string apiKey;
        private string onBehalfOfUser;
        private string baseUrl;
        private HttpClient client;

        public ApiClient(string baseUrl, string apiKey, string onBehalfOfUser = "")
        {
            this.apiKey = apiKey;
            this.onBehalfOfUser = onBehalfOfUser;
            this.baseUrl = baseUrl;

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
            if (onBehalfOfUser.Length > 0)
            {
                client.DefaultRequestHeaders.Add("X-On-Behalf-Of", onBehalfOfUser);
            }
        }

        public UserReservationService GetUserReservationService()
        {
            return new UserReservationService(baseUrl, client);
        }

        public CheckinService GetCheckinService()
        {
            return new CheckinService(baseUrl, client);
        }
    }
}
