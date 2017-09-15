using System;
using System.Collections.Generic;
using System.Linq;

namespace Mini
{
    public class Solution
    {
        private static Func<string, bool> isValid = (x) =>
        {
            if (x.StartsWith("0") || x.Contains("00"))
            {
                return false;
            }

            return true;
        };

        public static void Main()
        {
            // number of digits 2 <= N
            var N = int.Parse(Console.ReadLine());
            // base 2 <= K <= 10
            var K = int.Parse(Console.ReadLine());
            // N + K <= 18

            var digits = Enumerable.Range(0, K);

            var allCombos = CombinationsWithRepition(digits, N);

            
            var result = allCombos.Where(isValid);

            Console.WriteLine(result.Count());
        }

        static IEnumerable<string> CombinationsWithRepition(IEnumerable<int> input, int length)
        {
            if (length <= 0)
                yield return "";
            else
            {
                foreach (var i in input)
                {
                    foreach (var c in CombinationsWithRepition(input, length - 1))
                    {
                        yield return i + c;
                    }
                }
            }
        }
    }
}