using System.Collections.Generic;
using StockApiConnection.Core;

namespace StockApiConnection.Repository
{
    public interface IStockListRepository
    {
        List<string> GetSAndPList();
        List<string> GetNasdaqList();
        List<string> GetNyseList();
    }
}
