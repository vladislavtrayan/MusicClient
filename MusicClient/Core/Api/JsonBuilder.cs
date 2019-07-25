using RestSharp;

namespace Core.Api
{
    public class JsonBuilder
    {
        protected JsonObject RequestBody = new JsonObject();

        public virtual JsonObject GetRequestJsonBody() => RequestBody;

        protected void SetValueToJson(string key, object value, JsonObject obj)
        {
            if (obj.ContainsKey(key))
            {
                obj[key] = value;
            }
            else
            {
                obj.Add(key, value);
            }
        }

        protected void SetValueToJson(string key, object value)
        {
            SetValueToJson(key, value, RequestBody);
        }
    }
}
