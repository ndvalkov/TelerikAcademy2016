using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDSHomework
{
    //Write a method that finds the longest subsequence of 
    // equal numbers in given List and returns the result as new List<int>.
    class Solution
    {
        static void Main()
        {
            var list = new List<int> {12, 3, 4, 5, 3, 12, 12};
            var visited = new List<bool>(list.Count);

            var longest = 1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                var current = list[i];
                var occurrences = 0;
                if (visited[i])
                {
                    continue;
                }

                for (int j = 0; j < list.Count; j++)
                {
                    if (current == list[j])
                    {
                        occurrences++;

                        // ...
                    }

                }
            }

        }
    }
}
