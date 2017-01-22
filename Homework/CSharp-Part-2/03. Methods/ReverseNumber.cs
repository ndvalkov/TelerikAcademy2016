using System;

class ReverseNumber
{
    static void Main()
    {
        decimal number = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine(ReverseDigits(number));
    }

    static decimal ReverseDigits(decimal number)
    {
        char[] digits = number.ToString().ToCharArray();
        Array.Reverse(digits);
        string reversed = new string(digits);

        return Convert.ToDecimal(reversed);
    }
}