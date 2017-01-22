using System;
using System.Text;

class DecimalToHexConversion
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());

        Console.WriteLine(DecimalToHex(number));
    }

    static string DecimalToHex(ulong number)
    {
        var sb = new StringBuilder();
        while (number > 0)
        {
            var r = number % 16;
            number /= 16;
            sb.Insert(0, ((int)r).ToString("X"));
        }

        return sb.ToString();
    }
}