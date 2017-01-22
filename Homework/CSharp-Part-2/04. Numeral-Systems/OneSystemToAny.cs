using System;

class OneRingToRuleThemAll
{
    static void Main()
    {
        int sourceBase = int.Parse(Console.ReadLine());
        string number = Console.ReadLine();
        int targetBase = int.Parse(Console.ReadLine());

        Console.WriteLine(ConvertBaseToBase(number, sourceBase, targetBase));
    }

    static string ConvertBaseToBase(string number, int sourceBase, int targetBase)
    {
        if (sourceBase == targetBase)
        {
            return number;
        }

        // Use decimal as intermediary numerical system
        long numberInDecimal = ArbitraryToDecimalSystem(number, sourceBase);
        string numberInTargetBase = DecimalToArbitrarySystem(numberInDecimal, targetBase);

        return numberInTargetBase;
    }

    // http://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net
    static string DecimalToArbitrarySystem(long decimalNumber, int radix)
    {
        const int BitsInLong = 64;
        const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (radix < 2 || radix > Digits.Length)
            throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

        if (decimalNumber == 0)
            return "0";

        int index = BitsInLong - 1;
        long currentNumber = Math.Abs(decimalNumber);
        char[] charArray = new char[BitsInLong];

        while (currentNumber != 0)
        {
            int remainder = (int)(currentNumber % radix);
            charArray[index--] = Digits[remainder];
            currentNumber = currentNumber / radix;
        }

        string result = new string(charArray, index + 1, BitsInLong - index - 1);
        if (decimalNumber < 0)
        {
            result = "-" + result;
        }

        return result;
    }

    // http://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net
    public static long ArbitraryToDecimalSystem(string number, int radix)
    {
        const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (radix < 2 || radix > Digits.Length)
            throw new ArgumentException("The radix must be >= 2 and <= " +
                Digits.Length.ToString());

        if (string.IsNullOrEmpty(number))
            return 0;

        // Make sure the arbitrary numeral system number is in upper case
        number = number.ToUpperInvariant();

        long result = 0;
        long multiplier = 1;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char c = number[i];
            if (i == 0 && c == '-')
            {
                // This is the negative sign symbol
                result = -result;
                break;
            }

            int digit = Digits.IndexOf(c);
            if (digit == -1)
                throw new ArgumentException(
                    "Invalid character in the arbitrary numeral system number",
                    "number");

            result += digit * multiplier;
            multiplier *= radix;
        }

        return result;
    }
}