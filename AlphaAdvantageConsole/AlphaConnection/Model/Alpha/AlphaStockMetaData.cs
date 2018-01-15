using Newtonsoft.Json;
using StockApiConnection.Model;

namespace AlphaAdvantageConsole.AlphaConnection.Model.Alpha
{
    public class AlphaStockMetaData : StockMetaData
    {
        [JsonProperty("1. Information")]
        public override string Information { get; set; }
        [JsonProperty("2. Symbol")]
        public override string Symbol { get; set; }
        [JsonProperty("3. Last Refreshed")]
        public override string LastRefreshed { get; set; }
        [JsonProperty("5. Time Zone")]
        public override string TimeZone { get; set; }
    }
}
