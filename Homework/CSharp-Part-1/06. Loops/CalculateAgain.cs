using System;
using System.Numerics;

class CalculateAgain
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;

        for (int i = 2; i <= N; i++)
        {
            factorialN *= i;

            if (i <= K)
            {
                factorialK *= i;
            }
        }

        Console.WriteLine(factorialN / factorialK);
    }
}