using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem5
{
    class Solution
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var heights = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var ob = new OrderedBag<int>();
            var lastInserted = 0;
            var memo = new int[heights.Count];

            for (int i = heights.Count - 1; i >= 0; --i)
            {
                var current = heights[i];

                if (i == heights.Count - 1 || current > ob.GetLast())
                {
                    memo[i] = 0;
                    ob.Add(current);
                    lastInserted = current;
                    continue;
                }

                if (current < lastInserted)
                {
                    memo[i] = memo[i + 1] + 1;
                }
                else
                {
                    var currentIndex = -1;

                    for (int j = i + 1; j < heights.Count; j++)
                    {
                        var next = heights[j];
                        if (current < next)
                        {
                            currentIndex = j;
                            break;
                        }
                    }

                    if (currentIndex == -1)
                    {
                        memo[i] = 0;
                    }
                    else
                    {
                        memo[i] = memo[currentIndex] + 1;
                    }
                }

                ob.Add(current);
                lastInserted = current;
            }

            var longest = memo.ToList().Max();

            Console.WriteLine(longest);
            Console.WriteLine(string.Join(" ", memo));
        }
    }
}