using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    class Solution
    {
        private static SortedSet<string> combos = new SortedSet<string>();
        private static string keys = "1234567890";

        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var rels = Console.ReadLine();

            var sb = new StringBuilder();

            for (int i = 0; i < keys.Length; i++)
            {
                sb.Append(keys[i]);
                GenerateCombinations(rels, 0, sb, i);
                sb.Clear();
            }
            // GenerateCombinations(rels, 0, sb, 1);
            Console.WriteLine();
        }

        private static void GenerateCombinations(string rels, int index, StringBuilder combo, int currentKeyIndex)
        {
            if (index > rels.Length - 1)
            {
                if (combo.Length == rels.Length + 1)
                {
                    combos.Add(combo.ToString());
                }
                
                return;
            }

            if (currentKeyIndex < 0 || currentKeyIndex > keys.Length - 1)
            {
                return;
            }

            if (rels[index] == '=')
            {
                combo.Append(keys[currentKeyIndex]);
                GenerateCombinations(rels, index + 1, combo, currentKeyIndex);
                combo.Remove(combo.Length - 1, 1);
            }

            if (rels[index] == '>')
            {
                if (currentKeyIndex + 1 > keys.Length - 1)
                {
                    return;
                }
                combo.Append(keys[currentKeyIndex + 1]);
                GenerateCombinations(rels, index + 1, combo, currentKeyIndex + 1);
                combo.Remove(combo.Length - 1, 1);
            }

            if (rels[index] == '<')
            {
                if (currentKeyIndex - 1 < 0)
                {
                    return;
                }
                combo.Append(keys[currentKeyIndex - 1]);
                GenerateCombinations(rels, index + 1, combo, currentKeyIndex - 1);
            }

            
        }
    }
}