using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++) 
        {
            Console.WriteLine(i);
        }
    }
}