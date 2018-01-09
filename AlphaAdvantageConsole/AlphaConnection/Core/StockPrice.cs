using System;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class StockPrice
    {
        public DateTime StockDate { get; set; }
        public string StockOpen { get; set; }
        public string StockHigh { get; set; }
        public string StockLow { get; set; }
        public string StockClose { get; set; }
        public string StockVolume { get; set; }

        public StockPrice(DateTime date, string open, string high, string low, string close, string volume)
        {
            StockDate = date;
            StockOpen = open;
            StockHigh = high;
            StockLow = low;
            StockClose = close;
            StockVolume = volume;
        }
    }
}
