using System;
using System.Text;

class BinToHex
{
    static void Main()
    {
        string bin = Console.ReadLine();

        Console.WriteLine(BinaryToHex(bin));
    }

    static string BinaryToHex(string bin)
    {
        string[] nibbles = 
        {
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001",
            "1010",
            "1011",
            "1100",
            "1101",
            "1110",
            "1111"
        };

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
        string nibble;
        
        if (bin.Length <= 4)
        {
            nibble = bin.Substring(0, bin.Length);

            if (bin.Length == 3)
            {
                nibble = "0" + nibble;
            }
            else if (bin.Length == 2)
            {
                nibble = "00" + nibble;
            }
            else if (bin.Length == 1)
            {
                nibble = "000" + nibble;
            }

            result.Insert(0, hexCharToBinary[Array.IndexOf(nibbles, nibble), 0]);
        }
        else
        {
            for (int i = bin.Length - 4; i >= 0; i -= 4)
            {
                nibble = bin.Substring(i, 4);
                result.Insert(0, hexCharToBinary[Array.IndexOf(nibbles, nibble), 0]);

                if (i < 4 && i > 0)
                {
                    nibble = bin.Substring(0, i);
                    // add trailing zeroes for last nibble
                    if (i == 3)
                    {
                        nibble = "0" + nibble;
                    }
                    else if (i == 2)
                    {
                        nibble = "00" + nibble;
                    }
                    else
                    {
                        nibble = "000" + nibble;
                    }

                    result.Insert(0, hexCharToBinary[Array.IndexOf(nibbles, nibble), 0]);
                    break;
                }
            }
        }
        
        return result.ToString();
    }
}
