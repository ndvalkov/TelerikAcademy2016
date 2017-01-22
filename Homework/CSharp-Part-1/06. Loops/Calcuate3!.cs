using System;
using System.Numerics;

class Calculate3
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        int kToN = N - K;
        BigInteger factorialKToN = 1;

        for (int i = 2; i <= N; i++)
        {
            factorialN *= i;

            if (i <= K)
            {
                factorialK *= i;
            }

            if (i <= kToN)
            {
                factorialKToN *= i;
            }
        }

        Console.WriteLine(factorialN / (factorialK * factorialKToN));
    }
}