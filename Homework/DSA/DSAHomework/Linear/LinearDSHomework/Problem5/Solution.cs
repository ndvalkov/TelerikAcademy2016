using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    class Solution
    {
        // Write a program that removes from given sequence all negative numbers.
        static void Main()
        {
            var list = new List<int> { 12, 3, 4, -5, 3, -12, -12 };

            var result = list.Where(x => x >= 0);
            Console.WriteLine(string.Join(" ", result));


        }
    }
}
