using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Core.Api
{
    public class RestFrameworkClient
    {
        public RestClient Client { get; set; }

        public Uri BaseUri => Client.BaseUrl;

        public RestFrameworkClient(RestClient client)
        {
            Client = client;
            Client.AddHandler("text/html", new JsonDeserializer());
            Client.AddHandler("text/plain", new JsonDeserializer());
        }

        public IRestResponse<T> ExecuteRequest<T>(RestRequest request) where T : new()
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var restResponse = Client.Execute<T>(request);

            return restResponse;
        }

        public IRestResponse ExecuteRequest(RestRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var restResponse = Client.Execute(request);

            return restResponse;
        }

        public async Task<IRestResponse<T>> ExecuteRequestAsync<T>(RestRequest request) where T : new()
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var restResponse = await Client.ExecuteTaskAsync<T>(request);
            return restResponse;
        }

        public void GoToShipUri()
        {
            Client.BaseUrl = new Uri(Configuration.AuthorizationUri);
        }

        public void GoToRatesUri()
        {
            Client.BaseUrl = new Uri(Configuration.RatesInsightCalculatorUri);
        }

        public void GoToAuthorizationUri()
        {
            Client.BaseUrl = new Uri(Configuration.AuthorizationUri);
        }
    }
}