using System;

class MaximalCosecutive
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
       
//2
//3
//- 6
//- 1
//2
//- 1
//6
//4
//- 8
//8
        double[] numbers = new double[N];

        for (int i = 0; i < N; i++)
        {
            double currentElement = double.Parse(Console.ReadLine());
            numbers[i] = currentElement;
        }

        double maxSum = double.MinValue;
        double currentSum = 0;
        int tempStart = 0;

        int startIndex = 0;
        int endIndex = 1;

        for (int index = 0; index < numbers.Length; index++)
        {
            currentSum += numbers[index];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = tempStart;
                endIndex = index;
            }
            if (currentSum < 0)
            {
                currentSum = 0;
                tempStart = index + 1;
            }
        }

        Console.WriteLine(maxSum);
    }
}