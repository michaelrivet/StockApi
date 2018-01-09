using System.Collections.Generic;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class Stock
    {
        public string StockSymbol { get; set; }
        public string StockName { get; set; }

        public List<StockPrice> PriceList { get; set; }

        public Stock(string symbol, string name)
        {
            StockSymbol = symbol;
            StockName = name;
            PriceList = new List<StockPrice>();
        }
    }
}
