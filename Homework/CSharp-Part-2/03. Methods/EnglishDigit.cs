using System;

class EnglishDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(LastDigitToWord(number));

    }

    static string LastDigitToWord(int number)
    {
        string[] digits = 
        {
            "zero", "one", "two", "three",
            "four", "five", "six", "seven",
            "eight", "nine"
        };

        return digits[number % 10]; 
    }
}