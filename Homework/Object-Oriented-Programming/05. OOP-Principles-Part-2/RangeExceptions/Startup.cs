using System;
using System.Globalization;

namespace RangeExceptions
{
    class Startup
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter a number between 1 and 100: ");
                int input = int.Parse(Console.ReadLine());

                try
                {
                    if (input < 1 || input > 100)
                    {
                        throw new InvalidRangeException<int>(1, 100);
                    }

                    Console.WriteLine("Thanks!");
                    break;
                }
                catch (InvalidRangeException<int> e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                Console.WriteLine("Enter a Date between 1/31/2000 and 12/31/2016");

                try
                {
                    string format = "M/d/yyyy";
                    DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), format, provider);
                    DateTime startDate = DateTime.ParseExact("1/31/2000", format, provider);
                    DateTime endDate = DateTime.ParseExact("12/31/2016", format, provider);

                    if (dateTime < startDate || dateTime > endDate)
                    {
                        throw new InvalidRangeException<DateTime>(startDate, endDate);
                    }

                    Console.WriteLine("Thanks again.");
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidRangeException<DateTime> e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
