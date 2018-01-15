using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Model.Alpha;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockApiConnection.Core;
using StockApiConnection.Service;
using Stock = StockApiConnection.Core.Stock;
using StockPrice = StockApiConnection.Core.StockPrice;

namespace AlphaAdvantageConsole.AlphaConnection.Service
{
    class AlphaConnectionService : IConnectionService
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private readonly IStockModelDataBinderService<AlphaStockModel> _dataBinder;

        public AlphaConnectionService(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
            _dataBinder = new AlphaStockModelDataBinder();
        }

        public async Task<short> GetDailyData(string symbol)
        {
            var parameters = new List<ApiParam>
            {
                new ApiParam("function", "TIME_SERIES_DAILY"),
                new ApiParam("symbol", symbol),
            };

            var apiData = await CallAlphaVantageApi(BuildRequestUrl(parameters));

            return 12;
        }

        public Task<short> GetIntervalData(string symbol)
        {
            throw new NotImplementedException();
        }

        private async Task<AlphaStockModel> CallAlphaVantageApi(string stringRequest)
        {
            var client = new HttpClient();
            var res = await client.GetStringAsync(stringRequest);
            var alphaStock = _dataBinder.GenerateModelFromJson(res);

            return alphaStock;
        }

        private string BuildRequestUrl(List<ApiParam> apiParams)
        {
            var uri = apiParams.Aggregate(_apiUrl, (current, param) => current + param.ToApiString());
            uri += "&apikey=" + _apiKey;

            return uri;
        }
    }
}
