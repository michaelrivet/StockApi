using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Alpha;
using AlphaAdvantageConsole.AlphaConnection.Interface;
using AlphaAdvantageConsole.AlphaConnection.Model;
using AlphaAdvantageConsole.AlphaConnection.Model.Alpha;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlphaAdvantageConsole.AlphaConnection.Core
{
    public class AlphaStockModelDataBinder<T>: IStockModelDataBinder<T> where T : AlphaStockModel
    {
        public T GenerateModel(string data)
        {
            var alphaStockModel = JsonConvert.DeserializeObject<T>(data);
            alphaStockModel.TimeSeries = new List<AlphaStockDailyModel>();

            var timeSeries = JsonConvert.DeserializeObject<JObject>(data)["Time Series (Daily)"];

            foreach (var time in timeSeries)
            {
                var date = ((Newtonsoft.Json.Linq.JProperty)time).Name;
                var open = time.Children().Values("1. open").ToList()[0].Value<string>();
                var high = time.Children().Values("2. high").ToList()[0].Value<string>();
                var low = time.Children().Values("3. low").ToList()[0].Value<string>();
                var close = time.Children().Values("4. close").ToList()[0].Value<string>();
                var volume = time.Children().Values("5. volume").ToList()[0].Value<string>();

                var dailyModel = new AlphaStockDailyModel
                {
                    Date = date,
                    Open = open,
                    High = high,
                    Low = low,
                    Close = close,
                    Volume = volume
                };

                alphaStockModel.TimeSeries.Add(dailyModel);
            }

            return alphaStockModel;
        }
    }
}
