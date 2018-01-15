using System.Collections.Generic;
using StockApiConnection.Core;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class BAlphaStock : Stock
    {
        public string AlphaFoo { get; set; }

        public BAlphaStock(string symbol, string name) : base(symbol, name)
        {
            AlphaFoo = "foo";
        }
    }
}
