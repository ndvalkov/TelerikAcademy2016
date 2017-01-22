using System;

class GCD
{
    static void Main()
    {
        // C# - Euclidean Algorithm for GCD
        // http://dotnet-snippets.com/snippet/euclidean-algorithm-for-gcd/613
        string input = Console.ReadLine();
        string[] values = input.Split(' ');
        int A = int.Parse(values[0]);
        int B = int.Parse(values[1]);

        while (A != 0 && B != 0)
        {
            if (A > B)
            {
                A %= B;
            }
            else
            {
                B %= A;
            }
        }

        Console.WriteLine((A == 0) ? B : A);
    }
}