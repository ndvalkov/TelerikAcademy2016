using System;

class CompareArrays
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] first = new int[N];
        int[] second = new int[N];

        bool areEqual = true;
        for (int i = 0; i < N; i++)
        {
            int nextElement = int.Parse(Console.ReadLine());
            first[i] = nextElement;
        }

        for (int i = 0; i < N; i++)
        {
            int nextElement = int.Parse(Console.ReadLine());
            second[i] = nextElement;

            if (first[i] != second[i])
            {
                areEqual = false;
            }
        }

        Console.WriteLine(areEqual ? "Equal" : "Not equal");
    }
}