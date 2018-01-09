using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using AlphaAdvantageConsole.AlphaConnection.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace AlphaAdvantageConsole
{/*
    public class AlphaVantageRootObject
    {
        public MetaData MetaData;
        public List<TechnicalDataDate> TechnicalsByDate;
    }

    public class MetaData
    {
        public string Function;
        public string Interval;
        public string SeriesType;
        public string Symbol;
    }

    public class TechnicalDataDate
    {
        public DateTime Date;
        public List<TechnicalDataObject> Data;
    }

    public class TechnicalDataObject
    {
        public string TechnicalKey { get; set; }
        public double TechnicalValue { get; set; }
    }

    public class ApiParam
    {
        public string ParamName;
        public string ParamValue;

        public ApiParam(string paramNameIn, string paramValueIn)
        {
            ParamName = paramNameIn;
            ParamValue = paramValueIn;
        }

        public string ToApiString()
        {
            return $"&{ParamName}={ParamValue}";
        }
    }

    class AlphaConnections
    {

        public static async Task<Int16> GetTechnical(List<ApiParam> parameters, string apiKey,Stock stock)
        {

            var stringRequest = parameters.Aggregate(@"https://www.alphavantage.co/query?", (current, param) => current + param.ToApiString());
            stringRequest += "&apikey=" + apiKey;

            Int16 apiData = await CallAlphaVantageApi(stringRequest);
            stock.PriceList.Add(new StockPrice(DateTime.Now, "12", "", "", "", ""));
            return apiData;
        }

        public static async Task<Int16> CallAlphaVantageApi(string stringRequest)
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


    }*/
}
