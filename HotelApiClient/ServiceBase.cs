using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HotelApiClient
{
    public abstract class ServiceBase
    {
        protected HttpClient client;
        protected string baseUrl;

        public ServiceBase(string baseUrl, HttpClient client)
        {
            this.client = client;
            this.baseUrl = baseUrl;
        }
    }
}
