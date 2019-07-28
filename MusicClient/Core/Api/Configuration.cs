using System.Configuration;

namespace Core.Api
{
    public class Configuration
    {
        private static string GetEnvironmentVariable(string var, string defaultValue)
        {
            return  defaultValue;
        }

        public static string BaseUri => GetEnvironmentVariable("Uri", "https://downloadmusicvk.ru/audio/");

        public static string license => GetEnvironmentVariable("License", string.Empty);
        
        public static string AuthorizationUri => GetEnvironmentVariable("AuthorizationUri",string.Empty);
        
        public static string SearchUriSegment => GetEnvironmentVariable("SearchUriSegment","search");
        
        public static string DownloadUriSegment => GetEnvironmentVariable("DownloadUriSegment", "download");

        public static string RatesInsightCalculatorUri => GetEnvironmentVariable("FreightosRatesUri", string.Empty);

        public static string RatesInsightCalculatorSegmentUri => GetEnvironmentVariable("FreightosRatesUriSegment", string.Empty);

        public static string CalculatorsUriSegment => GetEnvironmentVariable("CalculatorsUriSegment", string.Empty);
    }
}
