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
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var currentResult = new BigInteger(1);
            var currentMultiplier = new BigInteger(4);
            var currentPower = new BigInteger(1);

            if (n % 2 == 1 || n == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    if (i % 2 == 1)
                    {
                        continue;
                    }
                    currentMultiplier = currentMultiplier * currentPower;
                    currentResult *= currentMultiplier;
                    currentPower = currentPower + 1;
                }

                Console.WriteLine(currentResult);
            }
        }
    }
}
