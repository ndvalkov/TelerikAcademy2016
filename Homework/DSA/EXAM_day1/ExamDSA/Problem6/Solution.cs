using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    class Solution
    {
        static void Main()
        {
            var pattern = Console.ReadLine();

            for (int i = 0; i < pattern.Length; i++)
            {
                int j = 0;
                for (; j < pattern.Length - i; j++)
                {
                    if (pattern[i + j] != pattern[pattern.Length - 1 - j])
                        break;
                }
                if (j == pattern.Length - i)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}