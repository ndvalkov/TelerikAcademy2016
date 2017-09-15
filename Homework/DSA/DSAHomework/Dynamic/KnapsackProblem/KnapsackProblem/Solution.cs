using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KnapsackProblem
{
    public class Solution
    {
        /*public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    Console.WriteLine("-------");
                    PrintMatrix(K);
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            
            return K[itemsCount, capacity];
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                    // Console.Write("{0,3} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }*/

        static void Main()
        {
            /* int[] value = { 2, 12, 5, 4, 3, 13 };
             int[] weight = { 3, 8, 4, 1, 2, 8};
             int capacity = 10;
             int itemsCount = 6;

            int result = KnapSack(capacity, weight, value, itemsCount);
            Console.WriteLine(result);
            */

            int nItems = 4;
            int knapsackSize = 10;
            int[] weights = { 5, 4, 6, 3 };
            int[] values = { 10, 40, 30, 50 };

            var matrix = new int[nItems + 1, knapsackSize + 1];

            var result = Knapsack(nItems - 1, knapsackSize, weights, values, matrix);

            Console.WriteLine(result);
            PrintMatrix(matrix);
        }

        static int Knapsack(int index, int size, int[] weights, int[] values, int[,] matrix)
        {
            var take = 0;
            var dontTake = 0;
            PrintMatrix(matrix);
            Console.WriteLine("-----------");
            if (matrix[index, size] != 0)
            {
                return matrix[index, size];
            }

            if (index == 0)
            {
                if (weights[0] <= size)
                {
                    matrix[index, size] = values[0];
                    return values[0];
                }
                else
                {
                    matrix[index, size] = 0;
                    return 0;
                }
            }

            if (weights[index] <= size)
            {
                take = values[index] + Knapsack(index - 1, size - weights[index], weights, values, matrix);
            }

            dontTake = Knapsack(index - 1, size, weights, values, matrix);

            matrix[index, size] = Math.Max(take, dontTake);

            return matrix[index, size];
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    // Console.Write("{0,3} ", matrix[i, j]);
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Solve()
        {
            var W = 10; // kg
            var N = 6; // number of products

            var values = new List<Product>();
            var beer = new Product
            {
                Name = "Beer",
                Weight = 3,
                Cost = 2
            };
            var vodka = new Product
            {
                Name = "Vodka",
                Weight = 8,
                Cost = 12
            };
            var cheese = new Product
            {
                Name = "Cheese",
                Weight = 4,
                Cost = 5
            };
            var nuts = new Product
            {
                Name = "Nuts",
                Weight = 1,
                Cost = 4
            };
            var ham = new Product
            {
                Name = "Ham",
                Weight = 2,
                Cost = 3
            };
            var whiskey = new Product
            {
                Name = "Whiskey",
                Weight = 8,
                Cost = 13
            };

            values.AddRange(new[] { beer, vodka, cheese, nuts, ham, whiskey });

            var m = new int[N, W];
        }

        static void SolveBruteForce()
        {
            var M = 10; // kg
            var N = 6; // number of products

            var products = new List<Product>();
            var beer = new Product
            {
                Name = "Beer",
                Weight = 3,
                Cost = 11
            };
            var vodka = new Product
            {
                Name = "Vodka",
                Weight = 2,
                Cost = 12
            };
            var cheese = new Product
            {
                Name = "Cheese",
                Weight = 5,
                Cost = 5
            };
            var nuts = new Product
            {
                Name = "Nuts",
                Weight = 3,
                Cost = 4
            };
            var ham = new Product
            {
                Name = "Ham",
                Weight = 1,
                Cost = 3
            };
            var whiskey = new Product
            {
                Name = "Whiskey",
                Weight = 8,
                Cost = 7
            };

            products.AddRange(new[] { beer, vodka, cheese, nuts, ham, whiskey });

            var d = CreateSubsets(products.ToArray());

            var allLessThanM = d.Where(x => x.Sum(y => y.Weight) <= M);

            var currentBest = int.MinValue;
            var currentBestSequence = new Product[] { };
            foreach (var productSequence in allLessThanM)
            {
                var sum = productSequence.Sum(x => x.Cost);
                if (sum > currentBest)
                {
                    currentBest = sum;
                    currentBestSequence = productSequence;
                }
            }

            foreach (var pr in currentBestSequence)
            {
                Console.WriteLine(pr);
            }
        }

        public static List<T[]> CreateSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }

            return subsets;
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
            Console.WriteLine($"Ellapsed: {(sw.ElapsedMilliseconds / iterations)}");
        }

        public class Product
        {
            public string Name { get; set; }

            public int Weight { get; set; }

            public int Cost { get; set; }

            public override string ToString()
            {
                return $"Name of product: {this.Name} + cost: {this.Cost} + weight: {this.Weight}";
            }
        }
    }
}