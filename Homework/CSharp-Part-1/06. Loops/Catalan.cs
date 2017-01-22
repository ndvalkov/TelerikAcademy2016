using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        BigInteger factorialN = 1;
        BigInteger factorialTwoTimesN = 1;

        for (int i = 2; i <= N * 2; i++)
        {
            factorialTwoTimesN *= i;

            if (i <= N)
            {
                factorialN *= i;
            }
        }

        Console.WriteLine(factorialTwoTimesN / (factorialN * (N + 1) * factorialN));
    }
}