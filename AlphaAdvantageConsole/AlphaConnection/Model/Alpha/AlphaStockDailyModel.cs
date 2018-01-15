using Newtonsoft.Json;
using StockApiConnection.Model;

namespace AlphaAdvantageConsole.AlphaConnection.Model.Alpha
{
    public class AlphaStockDailyModel : StockDailyModel
    {
        public override string Date { get; set; }
        [JsonProperty("1. open")]
        public override string Open { get; set; }
        [JsonProperty("1. high")]
        public override string High { get; set; }
        [JsonProperty("1. low")]
        public override string Low { get; set; }
        [JsonProperty("1. close")]
        public override string Close { get; set; }
        [JsonProperty("1. volume")]
        public override string Volume { get; set; }
    }
}
