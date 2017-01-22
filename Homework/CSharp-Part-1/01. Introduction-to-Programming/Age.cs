using System;

class Age
{
    public static void Main()
    {
        // statistical approximation accounting for leap
        double daysInYear = 365.2425; 

        String dateOfBirth = Console.ReadLine();
        DateTime parsedDate = DateTime.ParseExact(dateOfBirth, "MM.dd.yyyy", null);
        TimeSpan timeSpan = DateTime.Today.Subtract(parsedDate);
        int age = (int)(timeSpan.TotalDays / daysInYear);
        Console.WriteLine(age);
        Console.WriteLine(age + 10);
    }
}