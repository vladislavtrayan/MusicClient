using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Core.Api.RequestEntities
{
    public class DownloadTrackRequest
    {
        private CustomRequestBuilder Request { get; set; }

        public DownloadTrackRequest(string title,string artist,string url)
        {
            Request = new CustomRequestBuilder(Core.Api.Configuration.DownloadUriSegment);

            Request.WithResource("https://downloadmusicvk.ru/audio/download");
            Request.WithMethod(Method.GET);
            Request.WithParameter("url", title);
            Request.WithParameter("artist", title);
            Request.WithParameter("title", title);

        }

        public RestRequest GetRequest()
        {
            return Request.Build();
        }
    }
}
