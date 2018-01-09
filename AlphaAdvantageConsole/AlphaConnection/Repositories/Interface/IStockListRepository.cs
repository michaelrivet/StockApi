using AlphaAdvantageConsole.AlphaConnection.Core;

namespace AlphaAdvantageConsole.AlphaConnection.Repositories.Interface
{
    public interface IStockListRepository
    {
        StockList GetSAndPList();
        StockList GetNasdaqList();
        StockList GetNyseList();
    }
}
