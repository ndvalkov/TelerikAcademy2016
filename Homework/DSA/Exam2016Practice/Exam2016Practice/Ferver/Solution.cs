using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ferver
{
    class Solution
    {
        private static string input = @"13
1 3 200 11 3 5 64 1 1 1 12 21 13";

        private static double MaxProfit = 0;

        private static void Benchmark(Action act, int iterations)
        {
            GC.Collect();
            act.Invoke(); // run once outside of loop to avoid initialization costs

            for (int i = 0; i < iterations; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                act.Invoke();
                sw.Stop();
                Console.WriteLine(string.Format("Ellapsed: {0)}", sw.ElapsedMilliseconds / iterations));
            }

            //  Console.WriteLine($"Ellapsed: {sw.ElapsedMilliseconds}");
        }

        static void Main()
        {
            // buy one ounce
            // sell any number of ounces
            // pass

            var N = int.Parse(Console.ReadLine());
            var predictedPrices = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            GetMaxProfit(predictedPrices);
            Console.WriteLine(MaxProfit);
        }

        static void GetMaxProfit(double[] predictedPrices)
        {
            // pass
            ThreadStart firstTask = () => GetMaxPrice(predictedPrices, 1, 0d, 0);
            var firstThread = new Thread(firstTask);
            firstThread.Start();

            // buy one
            var profitDecr = predictedPrices[0];
            ThreadStart secondTask = () => GetMaxPrice(predictedPrices, 1, -profitDecr, 1);
            var secondThread = new Thread(secondTask);
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();
            // GetMaxPrice(predictedPrices, 0, 0d, 0);
        }

        private static void GetMaxPrice(double[] predictedPrices, int index, double totalProfit, int ouncesInPortfolio)
        {
            if (index >= predictedPrices.Length)
            {
                if (totalProfit > MaxProfit)
                {
                    MaxProfit = totalProfit;
                }
                return;
            }

            // pass
            GetMaxPrice(predictedPrices, index + 1, totalProfit, ouncesInPortfolio);
            // buy one ounce
            var profitDecr = predictedPrices[index];
            ouncesInPortfolio++;
            totalProfit -= profitDecr;
            GetMaxPrice(predictedPrices, index + 1, totalProfit, ouncesInPortfolio);
            // sell any number
            for (int i = 1; i <= ouncesInPortfolio; i++)
            {
                var profitIncr = predictedPrices[index];
                ouncesInPortfolio -= i;
                totalProfit += i * profitIncr;
                GetMaxPrice(predictedPrices, index + 1, totalProfit, ouncesInPortfolio);
            }
        }
    }
}