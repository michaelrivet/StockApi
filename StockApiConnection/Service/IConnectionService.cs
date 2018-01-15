using System.Threading.Tasks;
using StockApiConnection.Model;

namespace StockApiConnection.Service
{
    public interface IConnectionService<TStockModel>
    {
        Task<TStockModel> GetIntervalData(string symbol);
        Task<TStockModel> GetDailyData(string symbol);
    }
}
