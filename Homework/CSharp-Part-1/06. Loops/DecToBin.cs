using System;

class DecimalToBinary
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());

        int number = (int)input;
        string binaryString = "";

        while (number != 0)
        {
            if (number % 2 == 0)
            {
                binaryString = "0" + binaryString; // prepend 1
            }
            else
            {
                binaryString = "1" + binaryString; // prepend 0
            }

            number /= 2;
        }

        Console.WriteLine(binaryString);
    }
}