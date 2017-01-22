using System;

class MaximalCosecutive
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
     
        double[] numbers = new double[N];

        for (int i = 0; i < N; i++)
        {
            double currentElement = double.Parse(Console.ReadLine());
            numbers[i] = currentElement;
        }

        double mostFrequent = numbers[0];
        int frequency = 1;

        double currentNumber;
        int currentFrequency = 1;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            currentNumber = numbers[i];
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] == currentNumber)
                {
                    currentFrequency++;
                }
            }

            if (currentFrequency > frequency)
            {
                frequency = currentFrequency;
                mostFrequent = currentNumber;
            }

            currentFrequency = 1;
        }

        Console.WriteLine("{0} ({1} times)", mostFrequent, frequency);
    }
}