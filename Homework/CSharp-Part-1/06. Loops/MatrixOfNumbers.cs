using System;

class MatrixOfNumbers
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        // challenge accepted :)
        int offset = N - 2;
        int currentValue = 1;
        for (int i = 1; i <= N * N; i++)
        {
            Console.Write(currentValue + " ");

            if (i % N == 0)
            {
                Console.Write("\n");
                currentValue -= offset;
            }
            else
            {
                currentValue++;
            }
        }
    }
}