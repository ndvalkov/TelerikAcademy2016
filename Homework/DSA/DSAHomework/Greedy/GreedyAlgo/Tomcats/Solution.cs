using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Tomcats
{
    class Solution
    {
        static void Main()
        {
            var answers = new List<int>();
            string[] answersStrings = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < answersStrings.Length - 1; j++)
            {
                answers.Add(int.Parse(answersStrings[j]));
            }

            int n = answers.Count;
            answers.Sort();

            int t = 0, i = 0;
            // we want to find all pairs (x,c) such that:
            //  c is number of rabbits that claim there are x-1 other
            // rabbits of the same color.

            while (i < n)
            {
                int x = answers[i] + 1, c = 0;
                while (i < n && answers[i] == x - 1)
                {
                    c++;
                    i++;
                }

                while (c % x != 0)
                {
                    c++;
                }
                // The loop is actually equivalent to:
                // equivalent to c += (x - c%x) %x;
                t += c;
            }

            Console.WriteLine(t);
        }
    }
}
