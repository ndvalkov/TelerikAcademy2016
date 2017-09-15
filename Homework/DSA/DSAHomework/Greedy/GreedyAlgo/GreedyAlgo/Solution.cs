using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgo
{
    public class Solution
    {
        private string input = @"6
1 2
2 3
1 5
4 5
3 7
8 9
";

        public static void Main()
        {
            var intervals = int.Parse(Console.ReadLine());
            var intervalPairs = new List<Tuple<int, int>>();
            for (int i = 0; i < intervals; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var pair = new Tuple<int,int>(line[0], line[1]);
                intervalPairs.Add(pair);
            }

            var interArr = intervalPairs.ToArray();
            Array.Sort(interArr, (x, y) => x.Item2 - y.Item2);

            Console.WriteLine();

            var result = new List<Tuple<int, int>>();
            result.Add(interArr[0]);
            var end = interArr[0].Item2;
            for (int i = 1; i < interArr.Length; i++)
            {
                if (interArr[i].Item1 < end)
                {
                    continue;
                }

                result.Add(interArr[i]);
                end = interArr[i].Item2;
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].Item1 + " " + result[i].Item2);
            }
        }
    }
}