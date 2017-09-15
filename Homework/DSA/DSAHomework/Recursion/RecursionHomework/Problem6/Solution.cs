using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    class Solution
    {
        //        Write a program for generating and printing all subsets of k strings from given set of strings.
        //        Example: s = 
        //            {test, rock, fun }, k=2 → (test rock), (test fun), (rock fun)
        const int n = 3;
        const int k = 2;
        static string[] objects = 
        {
            "test", "rock", "fun"
        };
        static int[] arr = new int[k];
        static bool[] used = new bool[n];

        static void Main()
        {
            GenerateVariationsNoRepetitions(0);
        }

        static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void PrintVariations()
        {
            Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }
            Console.WriteLine(")");
        }
    }
}
