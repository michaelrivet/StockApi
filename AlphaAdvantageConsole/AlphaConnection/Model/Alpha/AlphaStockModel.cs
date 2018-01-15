using System.Collections.Generic;
using Newtonsoft.Json;
using StockApiConnection.Model;

namespace AlphaAdvantageConsole.AlphaConnection.Model.Alpha
{
    public class AlphaStockModel: StockModel<AlphaStockMetaData, AlphaStockDailyModel>
    {
        [JsonProperty("Meta Data")]
        public override AlphaStockMetaData MetaData { get; set; }
        public override List<AlphaStockDailyModel> TimeSeries { get; set; }
    }
}
