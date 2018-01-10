using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlphaAdvantageConsole.AlphaConnection.Model
{
    public class StockMetaData
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
