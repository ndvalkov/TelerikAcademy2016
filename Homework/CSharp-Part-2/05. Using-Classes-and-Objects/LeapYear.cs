using System;

class LeapYear
{
    static void Main()
    {
        int year = int.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(year);
        Console.WriteLine(isLeap ? "Leap" : "Common");
    }
}