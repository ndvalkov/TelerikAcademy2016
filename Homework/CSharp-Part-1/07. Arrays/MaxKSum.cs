using System;

class MaximalKSum
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        double[] numbers = new double[N];

        for (int i = 0; i < numbers.Length; i++)
        {
            double nextElement = double.Parse(Console.ReadLine());
            numbers[i] = nextElement;
        }

        // Use the Selection sort algorithm to sort ascending first (next problem)
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                // swap
                double temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }
        }

        double maxSum = 0;
        // Then take the sum of the last K elements to find the largest
        for (int i = numbers.Length - K; i < numbers.Length; i++)
        {
            maxSum += numbers[i];
        }

        Console.WriteLine(maxSum);
    }
}