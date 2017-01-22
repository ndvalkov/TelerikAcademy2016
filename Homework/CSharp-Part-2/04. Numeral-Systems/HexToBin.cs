using System;
using System.Text;

class HexToBin
{
    static void Main()
    {
        string hex = Console.ReadLine();

        Console.WriteLine(HexToBinary(hex));
    }

    static string HexToBinary(string hex)
    {
        string hexChar = "0123456789ABCDEF";

        string[,] hexCharToBinary =
        {
            { "0", "0000" },
            { "1", "0001" },
            { "2", "0010" },
            { "3", "0011" },
            { "4", "0100" },
            { "5", "0101" },
            { "6", "0110" },
            { "7", "0111" },
            { "8", "1000" },
            { "9", "1001" },
            { "A", "1010" },
            { "B", "1011" },
            { "C", "1100" },
            { "D", "1101" },
            { "E", "1110" },
            { "F", "1111" }
        };

        StringBuilder result = new StringBuilder();
        bool isSignificantBitSet = false;

        foreach (char c in hex)
        {
            string hexBinary = hexCharToBinary[hexChar.IndexOf(c), 1];

            if (!isSignificantBitSet)
            {
                // remove trailing zeroes
                hexBinary = int.Parse(hexBinary).ToString();
                if (hexBinary != "0")
                {
                    isSignificantBitSet = true;
                }
                else
                {
                    hexBinary = "";
                }
            }

            result.Append(hexBinary);
        }

        return result.ToString();
    }
}