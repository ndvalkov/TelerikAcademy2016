using System;

class PrintSequence
{
    public static void Main()
    {
        int currentPositive = 2;
        int currentNegative = -3;

        Console.WriteLine(currentPositive);
        Console.WriteLine(currentNegative);
        Console.WriteLine(currentPositive = currentPositive + 2);
        Console.WriteLine(currentNegative = currentNegative - 2);
        Console.WriteLine(currentPositive = currentPositive + 2);
        Console.WriteLine(currentNegative = currentNegative - 2);
        Console.WriteLine(currentPositive = currentPositive + 2);
        Console.WriteLine(currentNegative = currentNegative - 2);
        Console.WriteLine(currentPositive = currentPositive + 2);
        Console.WriteLine(currentNegative = currentNegative - 2);
    }
}