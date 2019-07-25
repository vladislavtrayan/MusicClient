using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ExternalMusicResource
{
    public class JsonRequestBodyBuilder
    {
        private static JsonObjectInstance jsonObjectInstance;

        public static JsonObjectInstance SetObjectValueToJson(string jsonObjectName, Dictionary<string, string> objectFields)
        {
            jsonObjectInstance = new JsonObjectInstance();
            jsonObjectInstance.ObjectName.Append(jsonObjectName);
            foreach (var element in objectFields)
            {
                if (element.Value.Contains("\"")) //if nested 
                {
                    jsonObjectInstance.ObjectBody.Append($"\"{element.Key}\": ");
                    jsonObjectInstance.ObjectBody.Append($"{{{element.Value}}},");
                }
                else
                {
                    jsonObjectInstance.ObjectBody.Append($"\"{element.Key}\": ");
                    jsonObjectInstance.ObjectBody.Append($"\"{element.Value}\",");
                }

            }

            jsonObjectInstance.ObjectBody.Remove(jsonObjectInstance.ObjectBody.Length - 1, 1); //delete last ","
            return jsonObjectInstance;
        }
    }

    public class JsonObjectInstance
    {
        public StringBuilder ObjectName { get; private set; } = new StringBuilder();
        public StringBuilder ObjectBody { get; private set; } = new StringBuilder();
        public StringBuilder JsonObject => new StringBuilder($"{{\"{ObjectName}\":{{{ObjectBody}}}}}");
    }

}