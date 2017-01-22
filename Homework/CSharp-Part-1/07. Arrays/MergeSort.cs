using System;
using System.Collections.Generic;
using System.Linq;

class BinarySearch
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        double[] numbers = new double[N];
        for (int i = 0; i < N; i++)
        {
            double nextElement = double.Parse(Console.ReadLine());
            numbers[i] = nextElement;
        }

        List<double> numbersSorted = MergeSort(numbers.ToList());

        // print
        for (int i = 0; i < numbersSorted.Count; i++)
        {
            Console.WriteLine(numbersSorted[i]);
        }
    }

    // Merge Sort - Recursive
    // https://www.youtube.com/watch?v=5NEQw1fhYsY
    private static List<double> MergeSort(List<double> numbers)
    {

        if (numbers.Count <= 1)
        {
            return numbers;
        }

        var left = new List<double>();
        var right = new List<double>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 > 0)
            {
                left.Add(numbers[i]);
            }
            else
            {
                right.Add(numbers[i]);
            }
        }

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }


    private static List<double> Merge(List<double> left, List<double> right)
    {
        var result = new List<double>();

        while (left.Count > 0 && right.Count > 0)
        {
            if (left.First() <= right.First())
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }
            else
            {
                result.Add(right.First());
                right.RemoveAt(0);
            }
        }

        while (left.Count > 0)
        {
            result.Add(left.First());
            left.RemoveAt(0);
        }

        while (right.Count > 0)
        {
            result.Add(right.First());
            right.RemoveAt(0);
        }

        return result;
    }
}