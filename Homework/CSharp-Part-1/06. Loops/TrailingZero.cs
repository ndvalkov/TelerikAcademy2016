using System;
using System.Numerics;

// Algorithm Description: (http://www.purplemath.com/modules/factzero.htm)
// Take the number that you've been given the factorial of.
//- Divide by 5; if you get a decimal, truncate to a whole number.
//- Divide by 5^2 = 25; if you get a decimal, truncate to a whole number.
//- Divide by 5^3 = 125; if you get a decimal, truncate to a whole number.
//- Continue with ever-higher powers of 5, until your division results in a number less than 1. Once the division is less than 1, stop.
//- Sum all the whole numbers you got in your divisions.This is the number of trailing zeroes.


class Trailing0InN
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int trailingZeros = 0;

        int currentPower = 1;
        while (true)
        {
            // Different result for 100000?
            //int powerOf5 = 1;
            //for (int i = 1; i <= currentPower; i++)
            //{
            //    powerOf5 *= 5;
            //}

            // N /= powerOf5;

            N /= 5;

            if (N < 1)
            {
                break;
            }

            trailingZeros += N;
            currentPower++;
        }

        Console.WriteLine(trailingZeros);
    }
}