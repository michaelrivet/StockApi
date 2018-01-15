using System.Collections.Generic;
using System.Threading.Tasks;
using StockApiConnection.Core;

namespace StockApiConnection.Service
{
    public interface IConnectionService
    {
        Task<short> GetIntervalData(string symbol);
        Task<short> GetDailyData(string symbol);
    }
}
