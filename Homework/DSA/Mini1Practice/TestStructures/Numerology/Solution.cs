using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Numerology
{
    class Solution
    {
        private static int n = 3;
        private static int k = 2;
        private static List<int> objects = new List<int>();
        private static int[] results = new int[10];

        static void Main()
        {
            var date = Console.ReadLine();

            var i = 0;
            foreach (var d in date)
            {
                objects.Add(d - '0');
            }

            GenerateVariationsNoRepetitions(ref objects);
            Console.WriteLine(string.Join(" ", results));
        }

        private static int PerformOperation(int a, int b)
        {
            return (a + b) * (a ^ b) % 10;
        }

        static void GenerateVariationsNoRepetitions(ref List<int> objects)
        {
            if (objects.Count <= 1)
            {
                results[objects[0]] += 1;
                return;
            }

            for (int i = 0; i < objects.Count - 1; i++)
            {
                var clone = objects.ToList();
                var res = PerformOperation(objects[i], objects[i + 1]);
                // results[res] += 1;
                objects.RemoveAt(i + 1);
                objects[i] = res;
                GenerateVariationsNoRepetitions(ref objects);
                objects = clone;
            }
        }

       
    }
}
