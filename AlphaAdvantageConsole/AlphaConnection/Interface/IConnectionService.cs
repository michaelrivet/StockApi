using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;

namespace AlphaAdvantageConsole.AlphaConnection.Interface
{
    interface IConnectionService
    {
        Task<short> GetData(List<ApiParam> parameters, Stock stock);
    }
}
