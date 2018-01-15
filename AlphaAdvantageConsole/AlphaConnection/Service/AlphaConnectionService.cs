using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Model.Alpha;
using StockApiConnection.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaAdvantageConsole.AlphaConnection.Service
{
    class AlphaConnectionService : IConnectionService<AlphaStockModel>
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

        public async Task<AlphaStockModel> GetDailyData(string symbol)
        {
            var parameters = new List<ApiParam>
            {
                new ApiParam("function", "TIME_SERIES_DAILY"),
                new ApiParam("symbol", symbol),
            };

            var apiData = await CallAlphaVantageApi(BuildRequestUrl(parameters));

            return apiData;
        }

        public Task<AlphaStockModel> GetIntervalData(string symbol)
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
