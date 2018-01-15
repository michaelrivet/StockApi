using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaAdvantageConsole.AlphaConnection.Core;
using AlphaAdvantageConsole.AlphaConnection.Repositories;
using AlphaAdvantageConsole.AlphaConnection.Service;
using Stock = StockApiConnection.Core.Stock;

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

        public static async Task MikeCallingMethod(List<string> stockList)
        {
            Console.WriteLine("Start MyCallingMethod");
            var connectionService = new AlphaConnectionService(@"https://www.alphavantage.co/query?", "N6MENFRJNKCIYXSQ");
            
            

            var res = await
                connectionService.GetDailyData(stockList[0]);

            Console.WriteLine($"Done MyCallingMethod {res}");
        }

    }
}
