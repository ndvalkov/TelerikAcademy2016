using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlsGoneWild
{
    class Solution
    {
        private static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();

        static void Main()
        {
            var K = int.Parse(Console.ReadLine());
            var skirts = Console.ReadLine();
            var numberOfGirls = int.Parse(Console.ReadLine());

            var results = new SortedSet<string>();

            var shirts = Enumerable.Range(0, K);
            var currentCombo = new string[4];
            GenerateCombos(shirts, skirts, numberOfGirls, results, currentCombo);
        }

        private static void GenerateCombos(IEnumerable<int> shirts, 
            string skirts, int numberOfGirls, SortedSet<string> results, string[] currentCombo)
        {
            for (int k = 0; k < numberOfGirls; k++)
            {
                for (int i = 0; i < shirts.Count() - 1; i++)
                {
                    for (int j = 0; j < skirts.Length; j++)
                    {
                        // currentCombo[] = 
                    }
                }
            }
        }
    }
}
