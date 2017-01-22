using System;

class GetLargest
{
    static void Main()
    {
        string numbers = Console.ReadLine();

        string[] split = numbers.Split(new char[] { ' ' });

        int firstNumber = int.Parse(split[0]);
        int secondNumber = int.Parse(split[1]);
        int thirdNumber = int.Parse(split[2]);

        Console.WriteLine(GetMax(firstNumber, secondNumber, thirdNumber));
    }

    static int GetMax(int first, int second, int third)
    {
        return Math.Max(first, Math.Max(second, third));
    }
}