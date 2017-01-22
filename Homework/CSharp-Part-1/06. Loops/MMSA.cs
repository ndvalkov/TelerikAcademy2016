using System;

class MMSAOfNNumbers
{
    static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine());

        double min = int.MaxValue;
        double max = int.MinValue;
        double sum = 0;
        double avg = 0;

        int counter = 0;
        while (counter < numbersCount)
        {
            double nextNumber = double.Parse(Console.ReadLine());

            if (nextNumber > max)
            {
                max = nextNumber;
            }

            if (nextNumber < min)
            {
                min = nextNumber;
            }

            sum += nextNumber;
            counter++;
        }

        avg = sum / counter;

        Console.WriteLine("min={0:0.00}", min);
        Console.WriteLine("max={0:0.00}", max);
        Console.WriteLine("sum={0:0.00}", sum);
        Console.WriteLine("avg={0:0.00}", avg);
    }
}