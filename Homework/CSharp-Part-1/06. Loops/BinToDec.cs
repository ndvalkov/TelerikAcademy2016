using System;

class BinaryToDecimal
{
    static void Main()
    {
        // string test = "11010101010101010101010101010101";
        string binaryNumber = Console.ReadLine();
        
        bool isInputValid = true;
        int decimalNumber = 0;

        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            char bit = binaryNumber[i];

            if (bit == '1')
            {
                int power = binaryNumber.Length - 1 - i;
                int currentPowerOf2 = 1; // for first bit

                for (int j = 0; j < power; j++)
                {
                    currentPowerOf2 *= 2;
                }

                decimalNumber += currentPowerOf2;
            }
            else if (bit == '0')
            {
                continue;
            }
            else
            {
                isInputValid = false;
            }
        }

        // Console.WriteLine(Convert.ToInt32(test, 2));
        Console.WriteLine(decimalNumber);
    }
}