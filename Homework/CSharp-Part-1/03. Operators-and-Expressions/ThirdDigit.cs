using System;

class ThirdDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int thirdDigit = (number / 100) % 10;
        int targetDigit = 7;
        Console.WriteLine((thirdDigit == targetDigit) ?
                          "true" : 
                          String.Format("false {0}", thirdDigit));
    }
}