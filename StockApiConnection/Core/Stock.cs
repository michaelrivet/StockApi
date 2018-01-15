using System.Collections.Generic;
using System.Security.Policy;

namespace StockApiConnection.Core
{
    public class Stock
    {
        public string StockSymbol { get; set; }
        public string StockName { get; set; }
        public List<StockPrice> Prices { get; set; }

        public Stock(string symbol, string name)
        {
            StockSymbol = symbol;
            StockName = name;
            Prices = new List<StockPrice>();
        }
    }
}
