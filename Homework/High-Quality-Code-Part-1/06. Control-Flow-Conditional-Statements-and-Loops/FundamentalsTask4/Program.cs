using System;

namespace FundamentalsTask4
{
    class MergingNumbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[] numbers = new int[N];

            for (int i = 0; i < N; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());
                numbers[i] = nextNumber;
            }

            int[] mergedNumbers = new int[N - 1];
            int[] summedNumbers = new int[N - 1];

            for (int i = 1; i < N; i++)
            {
                int firstNumber = numbers[i - 1];
                int secondNumber = numbers[i];

                string appended = string.Concat(firstNumber.ToString(),
                    secondNumber.ToString());

                string merged = "" + appended[1] + appended[2];
                int mergedNumber = int.Parse(merged);

                int sum = firstNumber + secondNumber;

                mergedNumbers[i - 1] = mergedNumber;
                summedNumbers[i - 1] = sum;
            }

            Console.WriteLine(string.Join(" ", mergedNumbers));
            Console.WriteLine(string.Join(" ", summedNumbers));
        }
    }
}
