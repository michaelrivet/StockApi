using System.Collections.Generic;
using AlphaAdvantageConsole.AlphaConnection.Alpha;
using Newtonsoft.Json;

namespace AlphaAdvantageConsole.AlphaConnection.Model.Alpha
{
    public class AlphaStockModel : BaseStockModel
    {
        [JsonProperty("Meta Data")]
        public AlphaStockMetaData StockMetaData { get; set; }
        public List<AlphaStockDailyModel> TimeSeries { get; set; }
    }
}
