using System;
using RestSharp;
using RestSharp.Authenticators;

namespace Core.Api
{
    public static class RestFrameworkClientFactory
    {
        private static IAuthenticator _authenticator = null; 
        
        //internal static TestContext TestContext { get; set; }

        public static Uri BaseEndPoint => new Uri(Configuration.BaseUri);

        public static RestFrameworkClient GetRestClient(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            return GetRestClient();
        }
        
        public static RestFrameworkClient GetRestClient(string endPoint)
        {
            var client = new RestClient(new Uri(endPoint)) {Authenticator = _authenticator};

            return new RestFrameworkClient(client);
        }

        public static RestFrameworkClient GetRestClient()
        {
            var client = new RestClient(BaseEndPoint) {Authenticator = _authenticator};

            return new RestFrameworkClient(client);
        }
    }
}
