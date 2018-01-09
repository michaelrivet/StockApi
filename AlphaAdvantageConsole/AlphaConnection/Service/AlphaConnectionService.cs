using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Interface;
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
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetStringAsync(stringRequest);
                    var newtmp = JsonConvert.DeserializeObject<JObject>(res);

                    var test = newtmp["Time Series (Daily)"].First.First.First;

                    for (int i = 0; i < newtmp["Time Series (Daily)"].Count(); i++)
                    {
                        //string open = newtmp["Time Series (Daily)"].ElementAt(1).ElementAt(0).ElementAt(0).ElementAt(0).ToString();
                        //string high = newtmp["Time Series (Daily)"].ElementAt(1).ElementAt(0).ElementAt(0).ElementAt(1).ToString();
                        //string low = newtmp["Time Series (Daily)"].ElementAt(1).ElementAt(0).ElementAt(0).ElementAt(2).ToString();
                        //string close = newtmp["Time Series (Daily)"].ElementAt(1).ElementAt(0).ElementAt(0).ElementAt(3).ToString();
                        //string volume = newtmp["Time Series (Daily)"].ElementAt(1).ElementAt(0).ElementAt(0).ElementAt(4).ToString();
                    }
                    
                    var temp = JsonConvert.DeserializeObject<JObject>(res);
                    return 12;
                }
            }
            catch (Exception e)
            {
                //fatal error
                return 0;
            }

        }
    }
}
