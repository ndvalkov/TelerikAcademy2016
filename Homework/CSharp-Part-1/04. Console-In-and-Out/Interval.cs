using System;

class Interval
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int divider = 5;
        int countOfDivisibleNums = 0;

        for (int currentNumber = firstNumber + 1; currentNumber < secondNumber; currentNumber++)
        {
            countOfDivisibleNums += (currentNumber % divider == 0) ? 1 : 0; 
        }

        Console.WriteLine(countOfDivisibleNums);
    }
}