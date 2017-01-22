using System;
using System.Linq;
using System.Numerics;

class IntegerCalculations
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' });
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        Console.WriteLine(Min(numbers));
        Console.WriteLine(Max(numbers));
        Console.WriteLine("{0:0.00}", Avg(numbers));
        Console.WriteLine(Sum(numbers));
        Console.WriteLine(Multiply(numbers));
    }

    static int Min(params int[] list)
    {
        return list.Min();
    }

    static int Max(params int[] list)
    {
        return list.Max();
    }

    static double Avg(params int[] list)
    {
        return list.Average();
    }

    static int Sum(params int[] list)
    {
        return list.Sum();
    }

    static BigInteger Multiply(params int[] list)
    {
        return list.Aggregate((BigInteger)1, (a, b) => a * b);
    }
}