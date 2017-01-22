using System;

class FourDigits
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int firstDigit = number / 1000;
        int secondDigit = (number / 100) % 10;
        int thirdDigit = (number / 10) % 10;
        int fourthDigit = number % 10;

        int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;
        String format = "{0}{1}{2}{3}";
        String reversed = String.Format(format,
                                        fourthDigit,
                                        thirdDigit,
                                        secondDigit,
                                        firstDigit);
        String lastInFirst = String.Format(format,
                                           fourthDigit,
                                           firstDigit,
                                           secondDigit,
                                           thirdDigit);
        String secondAndThirdSwitched = String.Format(format,
                                           firstDigit,
                                           thirdDigit,
                                           secondDigit,
                                           fourthDigit);

        Console.WriteLine(sum);
        Console.WriteLine(reversed);
        Console.WriteLine(lastInFirst);
        Console.WriteLine(secondAndThirdSwitched);
    }
}