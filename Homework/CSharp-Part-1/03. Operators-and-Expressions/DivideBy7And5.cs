using System;

class DivideBy7And5
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int firstDivider = 7;
        int secondDivider = 5;

        Console.Write((number % (firstDivider * secondDivider) == 0) ? "true " : "false ");
        Console.Write(number);
    }
}