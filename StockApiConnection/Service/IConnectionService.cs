using System.Threading.Tasks;
using StockApiConnection.Enums;
using StockApiConnection.Model;

namespace StockApiConnection.Service
{
    public interface IConnectionService<TStockModel>
    {
        Task<TStockModel> GetIntervalData(string symbol, IntradayInterval interval);
        Task<TStockModel> GetDailyData(string symbol);
    }
}
