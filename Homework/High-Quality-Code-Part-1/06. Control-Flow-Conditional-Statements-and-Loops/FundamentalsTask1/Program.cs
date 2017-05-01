using System;

namespace FundamentalsTask1
{
    class MagicalNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int firstDigit = number / 100;
            int secondDigit = (number / 10) % 10;
            int thirdDigit = number % 10;

            if (secondDigit % 2 == 0)
            {
                Console.WriteLine("{0:0.00}", (firstDigit + secondDigit) * thirdDigit);
            }
            else
            {
                Console.WriteLine("{0:0.00}", (firstDigit * secondDigit) / (double)thirdDigit);
            }
        }
    }
}
