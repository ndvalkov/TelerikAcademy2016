using System;

class ShortToBinaryConversion
{
    static void Main()
    {
        short number = short.Parse(Console.ReadLine());

        Console.WriteLine(ShortToBinary(number, 16));
    }

    // Recursive
    // http://stackoverflow.com/questions/1838963/easy-and-fast-way-to-convert-an-int-to-binary
    static string ShortToBinary(int value, int len)
    {
        return (len > 1 ? ShortToBinary(value >> 1, len - 1) : null) + "01"[value & 1];
    }
}