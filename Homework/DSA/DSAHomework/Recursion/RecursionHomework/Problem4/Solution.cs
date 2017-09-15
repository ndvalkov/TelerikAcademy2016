using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Solution
    {
        // Modify the previous program to skip duplicates:
        //n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
        static void Main()
        {
            var n = 4;
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
                GenerateCombinations(line, n, k, index + 1, i + 1);
            }
        }
    }
}