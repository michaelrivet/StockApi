using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Interface;
using AlphaAdvantageConsole.AlphaConnection.Model.Alpha;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlphaAdvantageConsole.AlphaConnection.Service
{
    class AlphaConnectionService : IConnectionService
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;
        private readonly IStockModelDataBinder<AlphaStockModel> _dataBinder;

        public AlphaConnectionService(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
            _dataBinder = new AlphaStockModelDataBinder<AlphaStockModel>();
        }

        public async Task<short> GetData(List<ApiParam> parameters, Stock stock)
        {
            var stringRequest = parameters.Aggregate(_apiUrl, (current, param) => current + param.ToApiString());
            stringRequest += "&apikey=" + _apiKey;

            var apiData = await CallAlphaVantageApi(stringRequest);
            stock.PriceList.Add(new StockPrice(DateTime.Now, "12", "", "", "", ""));
            return apiData;
        }

        private async Task<short> CallAlphaVantageApi(string stringRequest)
        {
            var client = new HttpClient();
            var res = await client.GetStringAsync(stringRequest);
            var alphaStock = _dataBinder.GenerateModel(res);

            return 12;
        }
    }
}
