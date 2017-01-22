using System;
using System.Linq;

class SumIntegers
{
    static void Main()
    {
        string input = Console.ReadLine();

        long[] numbers = input.Split(' ')
            .Select(long.Parse)
            .ToArray();

        long result = SumNumbers(numbers);
        Console.WriteLine(result);
    }

    static long SumNumbers(params long[] list)
    {
        return list.Sum(x => x);
    }
}