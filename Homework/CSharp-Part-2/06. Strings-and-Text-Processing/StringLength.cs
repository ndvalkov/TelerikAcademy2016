using System;

class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(input + new string('*', 20 - input.Length));
    }
}