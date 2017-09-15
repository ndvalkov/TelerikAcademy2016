using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    class Solution
    {
        // Write a program that removes from given sequence all numbers that occur odd number of times.
        // Example:
        // { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}

        static void Main()
        {
            Benchmark(Solve, 121);
           // Solve();
        }

        private static void Benchmark(Action act, int iterations)
        {
            GC.Collect();
            act.Invoke(); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                act.Invoke();
            }
            sw.Stop();
            Console.WriteLine($"Ellapsed: {sw.ElapsedMilliseconds}");
        }

        static void Solve()
        {
            // var list = new List<int> { 12, 3, 4, -5, 3, -12, -12 };
            var list = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var visited = new List<bool>();
            visited.AddRange(Enumerable.Repeat(false, list.Count));
            var oddIndices = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                visited[i] = true;

                var current = list[i];
                var occurrences = 1;
                var currentIndices = new List<int>();
                currentIndices.Add(i);
                for (int j = 0; j < list.Count; j++)
                {
                    if (visited[j])
                    {
                        continue;
                    }

                    if (current == list[j])
                    {

                        ++occurrences;
                        currentIndices.Add(j);
                        visited[j] = true;
                    }
                }

                if (occurrences % 2 == 1)
                {
                    oddIndices.AddRange(currentIndices);
                }
                currentIndices.Clear();
            }

            var res = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (oddIndices.Contains(i))
                {
                    continue;
                }

                res.Add(list[i]);
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
}
