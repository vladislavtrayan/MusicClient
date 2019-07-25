using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Serializers;

namespace Core.Api
{
    public class CustomRequestBuilder
    {
        private readonly RestRequest _request;
        private readonly StringBuilder _requestInformation = new StringBuilder();
        private readonly DataFormat _baseDataFormat = DataFormat.Json;
        public RestRequest Build() => _request;

        public CustomRequestBuilder()
        {
            _request = new RestRequest()
            {
                JsonSerializer = new JsonSerializer(),
                XmlSerializer = new XmlSerializer()
            };
        }


        public CustomRequestBuilder(string uri)
        {
            _request = new RestRequest(uri)
            {
                JsonSerializer = new JsonSerializer(),
                XmlSerializer = new XmlSerializer()
            };
        } 

        public CustomRequestBuilder WithResource(string resource)
        {
            _request.Resource = resource;
            _requestInformation.AppendLine($"Resource:{resource}");
            return this;
        }

        public CustomRequestBuilder SetContentType(string contentType)
        {
            _request.OnBeforeDeserialization = (response => { response.ContentType = contentType; });
            _requestInformation.AppendLine($"ContentType: {contentType}");
            return this;
        }

        public CustomRequestBuilder WithMethod(Method method)
        {
            _request.Method = method;
            _requestInformation.AppendLine($"Method:{method}");
            return this;
        }

        public CustomRequestBuilder SetJsonBody(JsonBuilder jsonBody)
        {
            if (jsonBody != null)
            {
                _requestInformation.AppendLine($"Body:{ _request.AddJsonBody(jsonBody.GetRequestJsonBody())}");
            }
            return this;
        }

        public CustomRequestBuilder WithCookie(string name,string value)
        {
            _request.AddCookie(name,value);
            _requestInformation.AppendLine($"Cookie Name:{name},Value:{value}");
            return this;
        }

        public CustomRequestBuilder WithUrlSegment(string name, string value)
        {
            _request.AddUrlSegment(name, value);
            _requestInformation.AppendLine($"Url segment:{name} with value:{value}");
            return this;
        }
        public CustomRequestBuilder WithParameter(string name, object value)
        {
            _request.AddParameter(name, value);
            _requestInformation.AppendLine($"Parameter: {name} with value:{value}");
            return this;

        }

        public CustomRequestBuilder WithBody(string body)
        {
            _requestInformation.AppendLine($"Body:{ _request.AddJsonBody(body)}");
            return this;

        }

        public CustomRequestBuilder WithParameters(Dictionary<string , object > parameters)
        {
            if (parameters == null)
            {
                return this;
            }

            foreach (var param in parameters)
            {
                this.WithParameter(param.Key, param.Value);
            }
            return this;
        }
        
        public CustomRequestBuilder WithParameters(IDictionary<string , string> parameters)
        {
            if (parameters == null)
            {
                return this;
            }

            foreach (var param in parameters)
            {
                this.WithParameter(param.Key, param.Value);
            }
            return this;
        }

        public CustomRequestBuilder WithParameters(IList<string> parameters)
        {
            var actualParams = new Dictionary<string, string>();
            for (var j = 0; j < parameters.Count() ; j++)
            {
                var keyValues = parameters[j].Split('=');
                if (keyValues.Length != 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var key = keyValues[0];
                var values = keyValues[1].Split(',');

                foreach (var value in values)
                {
                    actualParams.Add(key, value);
                }
            }

            return WithParameters(actualParams);
        }
    }
}
