using System;

class Erathosthene
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        //Input: an integer n > 1
        
        //Let A be an array of Boolean values, indexed by integers 2 to n,
        //initially all set to true.


        //for i = 2, 3, 4, ..., not exceeding √n:
        //  if A[i] is true:
        //    for j = i^2, i^2 + i, i^2 + 2i, i^2 + 3i, ..., not exceeding n :
        //      A[j] := false

        //Output: all i such that A[i] is true.

        int biggestPrime = 2;
        // http://introcs.cs.princeton.edu/java/14array/PrimeSieve.java.html
        // initially assume all integers are prime
        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        // mark non-primes <= n using Sieve of Eratosthenes
        for (int factor = 2; factor * factor <= n; factor++)
        {
            // if factor is prime, then mark multiples of factor as nonprime
            // suffices to consider mutiples factor, factor+1, ...,  n/factor
            if (isPrime[factor])
            {
                for (int j = factor; factor * j <= n; j++)
                {
                    isPrime[factor * j] = false;
                }
            }
        }

        // count primes
        int primes = 0;
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i]) biggestPrime = i;
        }

        Console.WriteLine(biggestPrime);


        //int biggestPrime = 2;
        //// initially all set to false
        //bool[] sieve = new bool[N + 1];

        //int length = (int)Math.Sqrt(N);
        //for (int i = 2; i <= length; i++)
        //{
        //    if (!sieve[i])
        //    {
        //        int multiplier = 0;
        //        for (int j = i * i; j <= N; j += multiplier * i)
        //        {
        //            sieve[j] = true;
        //            multiplier++;
        //        }
        //    }
        //}

        //for (int i = 2; i < sieve.Length; i++)
        //{
        //    if (!sieve[i])
        //    {
        //        biggestPrime = i;
        //    }
        //}

        //Console.WriteLine(biggestPrime);
    }
}