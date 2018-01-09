using System;
using System.Collections.Generic;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class TechnicalDataDate
    {
        public DateTime Date { get; set; }
        public List<Core.TechnicalDataObject> Data { get; set; }
    }
}
