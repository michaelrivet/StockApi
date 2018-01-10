using Newtonsoft.Json;

namespace AlphaAdvantageConsole.AlphaConnection.Model.Alpha
{
    public class AlphaStockMetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }
        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }
        [JsonProperty("3. Last Refreshed")]
        public string LastRefreshed { get; set; }
        [JsonProperty("5. Time Zone")]
        public string TimeZone { get; set; }
    }
}
