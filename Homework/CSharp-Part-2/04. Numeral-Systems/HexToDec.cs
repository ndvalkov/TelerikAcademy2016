using System;
using System.Text;

class HexToDec
{
    static void Main()
    {
        string hex = Console.ReadLine();

        Console.WriteLine(HexToDecimal(hex));
    }

    static ulong HexToDecimal(string hex)
    {
        string hexChars = "0123456789ABCDEF";
        hex = hex.ToUpper();

        ulong value = 0;
        for (int i = 0; i < hex.Length; i++)
        {
            value += (ulong)hexChars.IndexOf(hex[i]) << ((hex.Length - 1 - i) * 4);
        }
        return value;
    }
}