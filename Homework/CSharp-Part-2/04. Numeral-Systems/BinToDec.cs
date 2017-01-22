using System;

class BinaryToDecimalConversion
{
    static void Main()
    {
        string binary = Console.ReadLine();

        Console.WriteLine(BinaryToDecimal(binary));
    }

    static ulong BinaryToDecimal(string binary)
    {
        ulong result = 0;
        foreach (var c in binary)
        {
            result *= 2;
            result += (ulong)(c - '0');
        }

        return result;
    }
}
