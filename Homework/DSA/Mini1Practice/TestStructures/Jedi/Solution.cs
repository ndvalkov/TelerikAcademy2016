using System;
using System.Linq;
using System.Collections.Generic;

namespace TestStructures
{
    class Solution
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var jediWaiting = Console.ReadLine().Split(' ').ToList();

            var listOfMasters = new List<string>();
            var listOfKnights = new List<string>();
            var listOfPadawans = new List<string>();

            jediWaiting.ForEach((j) =>
            {
                if (j.StartsWith("M"))
                {
                    listOfMasters.Add(j);
                }

                if (j.StartsWith("K"))
                {
                    listOfKnights.Add(j);
                }

                if (j.StartsWith("P"))
                {
                    listOfPadawans.Add(j);
                }
            });

            listOfMasters.AddRange(listOfKnights);
            listOfMasters.AddRange(listOfPadawans);

            Console.WriteLine(string.Join(" ", listOfMasters));
        }
    }
}
