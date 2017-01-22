using System;

class HexToDecimal
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();

        long decimalNumber = 0;
        string hexDigits = "0123456789ABCDEF";

        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            char hexDigit = hexNumber[i];
            int multiplier = hexDigits.IndexOf(hexDigit);

            int power = hexNumber.Length - 1 - i;
            long currentPowerOf16 = 1; // for first digit

            for (int j = 0; j < power; j++)
            {
                currentPowerOf16 *= 16;
            }

            decimalNumber += multiplier * currentPowerOf16;
        }

        Console.WriteLine(decimalNumber);
    }
}
