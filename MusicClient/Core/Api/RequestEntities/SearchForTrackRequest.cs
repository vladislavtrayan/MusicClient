using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Core.Api.RequestEntities
{
    public class SearchForTrackRequest
    {
        private CustomRequestBuilder Request { get; set; }

        public SearchForTrackRequest(string title )
        {
            Request = new CustomRequestBuilder(Core.Api.Configuration.SearchUriSegment);

            Request.WithResource("https://downloadmusicvk.ru/audio/search");
            Request.WithMethod(Method.GET);
            Request.WithParameter("q", title);

        }

        public RestRequest GetRequest()
        {
            return Request.Build();
        }
    }
}
