using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlphaAdvantageConsole.AlphaConnection
{
    class AlphaConnectionService
    {
        private readonly string _apiKey;

        public AlphaConnectionService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public static async Task<short> GetAlphaData(List<ApiParam> parameters, string apiKey, Stock stock)
        {

            var stringRequest = parameters.Aggregate(@"https://www.alphavantage.co/query?", (current, param) => current + param.ToApiString());
            stringRequest += "&apikey=" + apiKey;

            Int16 apiData = await CallAlphaVantageApi(stringRequest);
            stock.priceList.Add(new StockPrice(DateTime.Now, "12", "", "", "", ""));
            return apiData;
        }

        public static async Task<short> CallAlphaVantageApi(string stringRequest)
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
