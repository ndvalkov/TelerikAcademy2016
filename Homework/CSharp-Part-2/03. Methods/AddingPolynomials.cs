using System;

class AdditionPolynomials
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine().Trim());

        string[] firstCoefficients = Console.ReadLine().Split(new char[] { ' ' });
        string[] secondCoefficients = Console.ReadLine().Split(new char[] { ' ' });

        long[] first = new long[n];
        long[] second = new long[n];

        for (int i = 0; i < n; i++)
        {
            first[i] = long.Parse(firstCoefficients[i]);
            second[i] = long.Parse(secondCoefficients[i]);
        }

        Console.WriteLine(string.Join(" ", AddPolynomials(first, second))); 
    }

    static long[] AddPolynomials(long[] first, long[] second)
    {
        int length = first.Length;
        long[] result = new long[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = first[i] + second[i];
        }

        return result;
    }
}