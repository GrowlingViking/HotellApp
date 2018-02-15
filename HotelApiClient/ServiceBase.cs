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

            if (baseUrl.EndsWith("/"))
            {
                // base url should always end with /
                throw new ArgumentException("baseUrl must not be specified with an ending /");
            }
        }

        protected string BuildFullUrl(string resource)
        {
            if (!resource.StartsWith("/"))
            {
                throw new ArgumentException("resource should not have a leading /");
            }
            return baseUrl + resource;
        }
    }
}
