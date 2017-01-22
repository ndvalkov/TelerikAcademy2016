using System;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] inputAsCharArr = input.ToCharArray();
        Array.Reverse(inputAsCharArr);
        Console.WriteLine(new string(inputAsCharArr));
    }
}