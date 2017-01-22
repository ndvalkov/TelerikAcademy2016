using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        uint N = uint.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            Console.Write(i + " ");
        }
    }
}