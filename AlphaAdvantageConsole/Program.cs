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
            Console.WriteLine("Start Program");

            var hardCodedStockListRepository = new HardCodedStockListRepository();
            var stockList = hardCodedStockListRepository.GetSAndPList();
            
            await MikeCallingMethod(stockList);

            Console.WriteLine("End Program");
            Console.ReadLine();
        }

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
