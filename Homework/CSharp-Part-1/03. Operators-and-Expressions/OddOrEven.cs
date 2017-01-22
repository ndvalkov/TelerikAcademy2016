using System;

class OddOrEven
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.Write((number % 2 == 0) ? "even " : "odd ");
        Console.Write(number);
    }
}