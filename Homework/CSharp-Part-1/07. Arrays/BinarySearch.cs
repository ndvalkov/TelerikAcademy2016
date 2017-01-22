using System;

class BinarySearch
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

        double X = double.Parse(Console.ReadLine());

        // First, sort the elements with the Selection sort algorithm 
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

        // Then use the Binary search algorithm to locate X
        bool found = false;
        int first = 0;
        int last = numbers.Length - 1;
        int mid = 0;
        double target = X;

        while (!found && first <= last)
        {
            mid = (first + last) / 2;

            if (target > numbers[mid])
            {
                first = mid + 1;
            }
            else if (target < numbers[mid])
            {
                last = mid - 1;
            }
            else
            {
                found = true;
            }
        }

        Console.WriteLine(found ? mid : -1);
    }
}