using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlphaAdvantageConsole.AlphaConnection.Model
{
    public class AlphaStockModel
    {
        [JsonProperty("Meta Data")]
        public StockMetaData StockMetaData { get; set; }
        
        public List<StockDailyModel> TimeSeries { get; set; }
    }
}
