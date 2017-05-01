namespace SortTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class SortingAlgorithms
    {
        public static void Main()
        {
            const int Min = 0;
            const int Max = 10;
            Random randNum = new Random();

            // UNCOMMENT FOR A SPECIFIC TEST
            // ------------------ int ----------------

            // CASE RANDOM
            /*int[] testVerySmallSize = Enumerable
                .Repeat(0, 10)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();*/

            /*int[] testSmallSize = Enumerable
                .Repeat(0, 50)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();*/

            /*int[] testMiddleSize = Enumerable
                .Repeat(0, 1000)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();*/

            /*int[] testLargeSize = Enumerable
                .Repeat(0, 10000)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();*/

            // CASE SORTED
            // Array.Sort(testLargeSize);
            // CASE SORTED REVERSED
            // Array.Sort(testLargeSize);
            // Array.Reverse(testLargeSize);

            // BenchmarkSortingFor(testVerySmallSize, 5, 100);
            // BenchmarkSortingFor(testSmallSize, 5, 100);
            // BenchmarkSortingFor(testMiddleSize, 5, 5);
            // BenchmarkSortingFor(testLargeSize, 5, 5);

            // -------------- double -----------

            /*double[] testVerySmallSize = Enumerable
                .Repeat(0, 10)
                .Select(i => randNum.NextDouble())
                .ToArray();*/

            /*double[] testSmallSize = Enumerable
                .Repeat(0, 50)
                .Select(i => randNum.NextDouble())
                .ToArray();*/

            /*double[] testMiddleSize = Enumerable
                .Repeat(0, 1000)
                .Select(i => randNum.NextDouble())
                .ToArray();*/

            /*double[] testLargeSize = Enumerable
                .Repeat(0, 10000)
                .Select(i => randNum.NextDouble())
                .ToArray();*/

            // BenchmarkSortingFor(testVerySmallSize, 5, 100);
            // BenchmarkSortingFor(testSmallSize, 5, 100);
            // BenchmarkSortingFor(testMiddleSize, 5, 5);
            // BenchmarkSortingFor(testLargeSize, 5, 5);

            // -------------- string -----------

            /*string[] testVerySmallSize = Enumerable
                .Repeat(0, 10)
                .Select(i => Path.GetRandomFileName().Substring(0, 4))
                .ToArray();*/

            /*string[] testSmallSize = Enumerable
                .Repeat(0, 50)
                .Select(i => Path.GetRandomFileName().Substring(0, 4))
                .ToArray();*/

            /*string[] testMiddleSize = Enumerable
                .Repeat(0, 1000)
                .Select(i => Path.GetRandomFileName().Substring(0, 4))
                .ToArray();*/

            /*string[] testLargeSize = Enumerable
                .Repeat(0, 10000)
                .Select(i => Path.GetRandomFileName().Substring(0, 4))
                .ToArray();*/

            // BenchmarkSortingFor(testVerySmallSize, 5, 100);
            // BenchmarkSortingFor(testSmallSize, 5, 100);
            // BenchmarkSortingFor(testMiddleSize, 5, 5);
            // BenchmarkSortingFor(testLargeSize, 5, 5); --- hangs
        }


        public static void DisplayExecutionTime(Action action, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                action();
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        public static void BenchmarkSortingFor<T>(T[] sourceArr, int ot, int iters) where T : IComparable
        {
            var outTimes = ot;
            var iterations = iters;

            Console.WriteLine($"---------- START BENCHMARK ---------");
            Console.WriteLine();
            Console.WriteLine($"Insertion sort:");
            BenchmarkInsertionSort(sourceArr, outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Selection sort:");
            BenchmarkSelectionSort(sourceArr, outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Quick sort:");
            BenchmarkQuickSort(sourceArr, outTimes, iterations);
            Console.WriteLine();
            Console.WriteLine("----------END---------");
            Console.WriteLine();
        }

        public static void BenchmarkInsertionSort<T>(T[] sourceArr, int outTimes, int iterations) where T : IComparable
        {
            DisplayExecutionTime(() =>
            {
                Loop(() => { PerformInsertionSort(sourceArr); }, iterations);
            }, outTimes);
        }

        public static void BenchmarkSelectionSort<T>(T[] sourceArr, int outTimes, int iterations) where T : IComparable
        {
            DisplayExecutionTime(() =>
            {
                Loop(() => { PerformSelectionSort(sourceArr); }, iterations);
            }, outTimes);
        }

        public static void BenchmarkQuickSort<T>(T[] sourceArr, int outTimes, int iterations) where T : IComparable
        {
            DisplayExecutionTime(() =>
            {
                Loop(() => { PerformQuicksort(sourceArr, 0, sourceArr.Length - 1);}, iterations);
            }, outTimes);
        }


        private static void Loop(Action action, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                action();
            }
        }

        public static T[] PerformInsertionSort<T>(T[] inputarray, Comparer<T> comparer = null)
        {
            var equalityComparer = comparer ?? Comparer<T>.Default;
            for (var counter = 0; counter < inputarray.Length - 1; counter++)
            {
                var index = counter + 1;
                while (index > 0)
                {
                    if (equalityComparer.Compare(inputarray[index - 1], inputarray[index]) > 0)
                    {
                        var temp = inputarray[index - 1];
                        inputarray[index - 1] = inputarray[index];
                        inputarray[index] = temp;
                    }
                    index--;
                }
            }
            return inputarray;
        }

        public static void PerformSelectionSort<T>(T[] arr) where T : IComparable
        {
            //pos_min is short for position of min
            int pos_min;
            T temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i; //set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    // We now use 'CompareTo' instead of '<'
                    if (arr[j].CompareTo(arr[pos_min]) < 0)
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }

        public static void PerformQuicksort<T>(T[] elements, int left, int right) where T : IComparable
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                PerformQuicksort(elements, left, j);
            }

            if (i < right)
            {
                PerformQuicksort(elements, i, right);
            }
        }
    }
}