using System.Collections.Generic;

namespace StockApiConnection.Model
{
    public class StockModel<TMetaData, TDailyModel> where TMetaData : StockMetaData where TDailyModel : StockDailyModel
    {
        public virtual TMetaData MetaData { get; set; }
        public virtual List<TDailyModel> TimeSeries { get; set; }
    }
}
