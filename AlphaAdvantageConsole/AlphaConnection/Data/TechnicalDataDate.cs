using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaAdvantageConsole.AlphaConnection.Data
{
    public class TechnicalDataDate
    {
        public DateTime Date { get; set; }
        public List<TechnicalDataObject> Data { get; set; }
    }
}
