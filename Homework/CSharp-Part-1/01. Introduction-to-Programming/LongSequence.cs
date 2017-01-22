using System;

class LongSequence
{
    public static void Main()
    {
        int currentPositive = 2;
        int currentNegative = -3;
        int position = 0;
        int end = 1000;

        do
        {
            Console.WriteLine(currentPositive);
            Console.WriteLine(currentNegative);
            currentPositive = currentPositive + 2;
            currentNegative = currentNegative - 2;
            position = position + 2;
        } while(position < end);
    }
}