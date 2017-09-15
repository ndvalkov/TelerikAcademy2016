using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Solution
    {
        private static ulong combos;

        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var CatalanN = new BigInteger(1);
            var Term = 0;
            while (N-- > 1)
            {
                Term++;
                CatalanN = CatalanN * (4 * Term + 2) / (Term + 2);
            }

            Console.WriteLine(CatalanN);
        }
    }
}
