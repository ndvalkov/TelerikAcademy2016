using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skobi
{
    public class Solution
    {
        public static void Main()
        {
            string seq = "()?";

            var characters = Console.ReadLine();

            var result = GetAllCombos(characters);

            var countOfValid = 0;
            result.ForEach((x) =>
            {
                var isValidEx = checkValidity(x);
                if (isValidEx)
                {
                    countOfValid++;
                }
            });

            Console.WriteLine(countOfValid);


            // ??
        }

        private static List<string> GetAllCombos(string chars)
        {
            var combos = new List<string>();
            GetAllCombos(0, chars, combos);
            return combos;
        }

        private static void GetAllCombos(int index, string chars, List<string> combos)
        {
            if (index == chars.Length)
            {
                combos.Add(chars);
                return;
            }

            if (chars[index] == '?')
            {
                var c = chars.ToCharArray();
                c[index] = '(';
                GetAllCombos(index + 1, new string(c), combos);
                c[index] = ')';
                GetAllCombos(index + 1, new string(c), combos);
            }
            else
            {
                GetAllCombos(index + 1, chars, combos);
            }
        }

        private static bool checkValidity(string expression)
        {
            Stack<char> openStack = new Stack<char>();
            foreach (char c in expression)
            {
                switch (c)
                {
                    case '(':
                        openStack.Push(c);
                        break;
                    case ')':
                        if (openStack.Count == 0 || openStack.Peek() != '(')
                        {
                            return false;
                        }
                        openStack.Pop();
                        break;
                    default:
                        break;
                }
            }
            return openStack.Count == 0;
        }
    }
}
