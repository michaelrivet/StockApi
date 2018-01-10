using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlphaAdvantageConsole.AlphaConnection.Alpha
{
    public class AlphaStockDailyModel
    {
        public string Date { get; set; }
        [JsonProperty("1. open")]
        public string Open { get; set; }
        [JsonProperty("1. high")]
        public string High { get; set; }
        [JsonProperty("1. low")]
        public string Low { get; set; }
        [JsonProperty("1. close")]
        public string Close { get; set; }
        [JsonProperty("1. volume")]
        public string Volume { get; set; }
    }
}
