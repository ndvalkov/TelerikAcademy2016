using System;

class MaxSum
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] dimensions = input.Split(new char[] { ' ' });
        int N = int.Parse(dimensions[0]);
        int M = int.Parse(dimensions[1]);
        double[,] matrix = new double[N, M];

        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine();

            string[] numbers = input.Split(new char[] { ' ' });

            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = double.Parse(numbers[j]);
            }
        }

        double maxSum = double.MinValue;
        double currentSum = 0;

        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                    + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                    + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            currentSum = 0;
        }

        Console.Write(maxSum);
    }
}