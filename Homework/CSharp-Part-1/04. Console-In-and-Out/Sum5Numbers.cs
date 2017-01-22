using System;

class SumOf5Numbers
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());
        int fourthNumber = int.Parse(Console.ReadLine());
        int fifthNumber = int.Parse(Console.ReadLine());

        int sum = firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber;

        Console.WriteLine(sum);
    }
}