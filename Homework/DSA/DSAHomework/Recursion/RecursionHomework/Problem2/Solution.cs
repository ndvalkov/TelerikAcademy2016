using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Solution
    {
        // Write a recursive program for generating and printing all the combinations 
        // with duplicatesof k elements from n-element set.Example:
        // n= 3, k= 2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
        static void Main()
        {
            var n = 3;
            var k = 2;
            var line = new int[k];
            GenerateCombinations(line, n, k, 0, 0);
        }

        private static void GenerateCombinations(int[] line, int n, int k, int index, int start)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", line));
                return;
            }

            for (int i = start; i < n; i++)
            {

                line[index] = i + 1;
                GenerateCombinations(line, n, k, index + 1, i);
            }
        }
    }
}
