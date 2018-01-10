using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Interface;
using AlphaAdvantageConsole.AlphaConnection.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlphaAdvantageConsole.AlphaConnection.Service
{
    class AlphaConnectionService : IConnectionService
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;

        public AlphaConnectionService(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
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
            var alphaStock = JsonConvert.DeserializeObject<AlphaStockModel>(res);
            alphaStock.TimeSeries = new List<StockDailyModel>();
                    
            var temp = JsonConvert.DeserializeObject<JObject>(res);
            var timeSeries = temp["Time Series (Daily)"];
            foreach (var time in timeSeries)
            {
                var date = ((Newtonsoft.Json.Linq.JProperty) time).Name;
                var open = time.Children().Values("1. open").ToList()[0].Value<string>();
                var high = time.Children().Values("2. high").ToList()[0].Value<string>();
                var low = time.Children().Values("3. low").ToList()[0].Value<string>();
                var close = time.Children().Values("4. close").ToList()[0].Value<string>();
                var volume = time.Children().Values("5. volume").ToList()[0].Value<string>();

                var dailyModel = new StockDailyModel
                {
                    Date = date,
                    Open = open,
                    High = high,
                    Low = low,
                    Close = close,
                    Volume = volume
                };
                    
                alphaStock.TimeSeries.Add(dailyModel);    
            }

            return 12;
        }
    }
}
