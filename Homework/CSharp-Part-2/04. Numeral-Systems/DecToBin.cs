using System;

class DecimalToBinaryConversion
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());

        Console.WriteLine(DecimalToBinary(number));
    }

    static string DecimalToBinary(ulong number)
    {
        ulong remainder;
        string result = string.Empty;
        while (number > 0)
        {
            remainder = number % 2;
            number /= 2;
            result = remainder.ToString() + result;
        }

        return result;
    }
}