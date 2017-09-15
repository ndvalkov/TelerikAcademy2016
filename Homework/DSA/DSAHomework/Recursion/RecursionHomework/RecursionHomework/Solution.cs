using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionHomework
{
    class Solution
    {
        // Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
        //Examples:
        //         1 1
        //n= 2->  1 2
        //         2 1
        //         2 2
        //
        //         1 1 1
        //         1 1 2
        //         1 1 3
        //         1 2 1
        //n= 3->  ...
        //         3 2 3
        //         3 3 1
        //         3 3 2
        //         3 3 3

        static void Main()
        {
            var n = 3;
            var line = new int[n];
            PrintNested(line, 0, n);
        }

        private static void PrintNested(int[] line, int index, int num)
        {
            if (index >= num)
            {
                Console.WriteLine(string.Join(" ", line));
                return;
            }

            for (int j = 0; j < num; j++)
            {
                line[index] = j + 1;
                PrintNested(line, index + 1, num);
            }
        }
    }
}
