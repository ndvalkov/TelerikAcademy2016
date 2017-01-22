using System;

class DecimalToHex
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        string hexString = "";
        string hexDigits = "0123456789ABCDEF";

        while (number > 0)
        {
            char nextDigit = hexDigits[(int)(number % 16)];
            number /= 16;
            hexString = nextDigit + hexString; // prepend hex digit
        }

        Console.WriteLine(hexString);
    }
}