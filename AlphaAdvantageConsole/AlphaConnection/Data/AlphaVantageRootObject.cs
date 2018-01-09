using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaAdvantageConsole.AlphaConnection.Data
{
    public class AlphaVantageRootObject
    {
        public MetaData MetaData { get; set; }
        public List<TechnicalDataDate> TechnicalsByDate { get; set; }
    }
}
