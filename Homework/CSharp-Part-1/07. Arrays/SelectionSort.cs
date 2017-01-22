using System;

class SelectionSort
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        double[] numbers = new double[N];

        for (int i = 0; i < numbers.Length; i++)
        {
            double nextElement = double.Parse(Console.ReadLine());
            numbers[i] = nextElement;
        }

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


        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
