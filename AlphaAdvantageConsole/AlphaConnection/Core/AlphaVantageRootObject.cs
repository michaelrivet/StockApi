using System.Collections.Generic;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class AlphaVantageRootObject
    {
        public MetaData MetaData { get; set; }
        public List<TechnicalDataDate> TechnicalsByDate { get; set; }
    }
}
