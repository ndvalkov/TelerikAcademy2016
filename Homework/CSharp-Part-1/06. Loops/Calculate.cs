using System;

class Calculate
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());

        double sum = 1;
        long currentFactorial = 1;
        double currentPower = 1;

        for (int i = 1; i <= N; i++)
        {
            currentFactorial *= i;
            currentPower *= x;
            sum += currentFactorial / currentPower;
        }

        Console.WriteLine("{0:0.00000}", sum);
    }
}