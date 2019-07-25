using System.Configuration;

namespace Core.Api
{
    public class Configuration
    {
        private static string GetEnvironmentVariable(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string BaseUri => GetEnvironmentVariable("Uri",string.Empty);

        public static string license => GetEnvironmentVariable("License", string.Empty);
        
        public static string AuthorizationUri => GetEnvironmentVariable("AuthorizationUri",string.Empty);
        
        public static string ShipmentsUriSegment => GetEnvironmentVariable("ShipmentsUriSegment",string.Empty);
        
        public static string LoginUriSegment => GetEnvironmentVariable("LoginUriSegment", string.Empty);

        public static string RatesInsightCalculatorUri => GetEnvironmentVariable("FreightosRatesUri", string.Empty);

        public static string RatesInsightCalculatorSegmentUri => GetEnvironmentVariable("FreightosRatesUriSegment", string.Empty);

        public static string CalculatorsUriSegment => GetEnvironmentVariable("CalculatorsUriSegment", string.Empty);
    }
}
