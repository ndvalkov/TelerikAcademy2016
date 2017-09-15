using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10
{
    class Solution
    {
        private static bool backTrack = false;
        private static List<int> result = new List<int>();
        // We are given numbers N and M and the following operations:
        //N = N+1
        //N = N+2
        //N = N*2
        //Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
        //Hint: use a queue.
        //Example: N = 5, M = 16
        //Sequence: 5 → 7 → 8 → 16
        static void Main()
        {
            var N = 5;
            var M = 16;
            var current = N;

            GenerateSequences(N, M, result);
            
            Console.WriteLine(string.Join(" ", result));
        }

        private static bool GenerateSequences(int current, int m, List<int> seq) 
        {
            if (current > m)
            {
                return false;
            }

            if (current == m)
            {
                seq.Add(current);
                backTrack = true;
                return true;
            }


            var res = GenerateSequences(current + 1, m, seq);
            if (backTrack && res)
            {
                seq.Add(current);
                return true;
            }

            res = GenerateSequences(current + 2, m, seq);

            if (backTrack && res)
            {
                result.Add(current);
                return true;
            }

            res = GenerateSequences(current * 2, m, seq);

            if (backTrack && res)
            {
                result.Add(current);
                return true;
            }

            return false;
        }
    }
}