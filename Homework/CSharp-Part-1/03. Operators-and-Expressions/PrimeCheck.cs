using System;

class PrimeCheck
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int maxValue = 100;
        int boundary = (int)Math.Sqrt(maxValue); // 10

        // check for dividers in the range [2, 10]  
        bool isPrime = (number > 1) && 
            !((number % 2 == 0) && (number != 2)) &&
            !((number % 3 == 0) && (number != 3)) &&
            !((number % 4 == 0) && (number != 4)) &&
            !((number % 5 == 0) && (number != 5)) &&
            !((number % 6 == 0) && (number != 6)) &&
            !((number % 7 == 0) && (number != 7)) &&
            !((number % 8 == 0) && (number != 8)) &&
            !((number % 9 == 0) && (number != 9)) &&
            !((number % boundary == 0) && (number != boundary));

        Console.WriteLine(isPrime.ToString().ToLower());
    }
}