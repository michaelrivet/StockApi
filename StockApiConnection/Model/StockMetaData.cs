using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiConnection.Model
{
    public class StockMetaData
    {
        public virtual string Information { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string LastRefreshed { get; set; }
        public virtual string TimeZone { get; set; }
    }
}
