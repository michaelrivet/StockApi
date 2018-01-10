using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Repositories;
using AlphaAdvantageConsole.AlphaConnection.Service;

namespace AlphaAdvantageConsole
{

    class Program
    {
        static async Task Main(string[] args)
        {
            // Testing branching

            Console.WriteLine("Start Program");

            var hardCodedStockListRetriever = new HardCodedStockListRepository();
            var stockList = hardCodedStockListRetriever.GetSAndPList();
            
            await MikeCallingMethod(stockList);

            Console.WriteLine("End Program");
            Console.ReadLine();
        }

        /*
        public static string GITHUBCallingMethod()
        {
            string ticker = "AAPL";
            string API_KEY = "N6MENFRJNKCIYXSQ";

            var parameters = new List<ApiParam>
            {
                new ApiParam("function", AvFuncationEnum.Sma.ToDescription()),
                new ApiParam("symbol", ticker),
                new ApiParam("interval", AvIntervalEnum.Daily.ToDescription()),
                new ApiParam("time_period", "5"),
                new ApiParam("series_type", AvSeriesType.Open.ToDescription()),
            };

            var task = Task.Run(async () =>
            {
                var SMA_5 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
                var SMA_20 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var SMA_50 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
                var SMA_200 = await GetTechnical(parameters, API_KEY);

                return "";
            });
            return task.Result;
        }*/

        public static async Task MikeCallingMethod(StockList stockList)
        {
            Console.WriteLine("Start MyCallingMethod");
            var connectionService = new AlphaConnectionService(@"https://www.alphavantage.co/query?", "N6MENFRJNKCIYXSQ");
            
            var parameters = new List<ApiParam>
            {
                new ApiParam("function", "TIME_SERIES_DAILY"),
                new ApiParam("symbol", stockList.Stocks[0].StockSymbol),
            };

            var res = await
                connectionService.GetData(parameters, stockList.Stocks[0]);

            Console.WriteLine($"Done MyCallingMethod {res}");
        }

    }
}
