using System.Collections.Generic;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class StockList
    {
        public string Name { get; set; }
        public List<Stock> Stocks { get; set; }

        public StockList(string name, List<Stock> stocks)
        {
            Name = name;
            Stocks = stocks;
        }
    }
}
