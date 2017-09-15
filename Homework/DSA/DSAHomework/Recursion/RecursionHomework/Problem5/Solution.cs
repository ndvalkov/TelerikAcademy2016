using System;

namespace Problem5
{
    class Solution
    {
        private static int n = 3;
        private static int k = 2;
        private static int[] arr = new int[k];
        static string[] objects = {
            "hi", "a", "b"
        };

        // Write a recursive program for generating and printing all ordered k-element subsets from n-element set(variations Vkn).
        // Example: n=3, k=2, set = 
        // {hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
        static void Main()
        {
            GenerateVariationsWithRepetitions(0);
        }

        static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        static void PrintVariations()
        {
            Console.Write("(" + string.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }
            Console.WriteLine(")");
        }
    }
}
