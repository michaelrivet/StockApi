using System.Collections.Generic;

namespace StockApiConnection.Repository
{
    public interface IStockListRepository
    {
        List<string> GetSAndPList();
        List<string> GetNasdaqList();
        List<string> GetNyseList();
    }
}
