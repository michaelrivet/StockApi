using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiConnection.Model
{
    public class StockDailyModel
    {
        public virtual string Date { get; set; }
        public virtual string Open { get; set; }
        public virtual string High { get; set; }
        public virtual string Low { get; set; }
        public virtual string Close { get; set; }
        public virtual string Volume { get; set; }
    }
}
