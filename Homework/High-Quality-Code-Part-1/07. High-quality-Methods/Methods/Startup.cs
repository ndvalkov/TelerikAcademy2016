using System;
using Methods.Utils;

namespace Methods
{
    class Startup
    {
        public static void Main()
        {
            Logger logger = new Logger();

            Console.WriteLine(MathUtils.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(MathUtils.NumberToDigit(5));
            Console.WriteLine(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            logger.Log(1.3, Logger.Format.Standard);
            logger.Log(0.75, Logger.Format.Percent);
            logger.Log(2.30, Logger.Format.Padded);

            var point1 = new MathUtils.Point(3, -1);
            var point2 = new MathUtils.Point(3, 2.5);

            Console.WriteLine(MathUtils.CalculateDistance(point1, point2));
            Console.WriteLine("Horizontal? " + MathUtils.IsHorizontalDistance(point1, point2));
            Console.WriteLine("Vertical? " + MathUtils.IsVerticalDistance(point1, point2));

            var peterDb = new DateTime(1982, 3, 2); 
            var stelaDb = new DateTime(1982, 3, 3); 

            Student peter = new Student("Peter", "Ivanov", peterDb);
            Student stella = new Student("Stella", "Markova", stelaDb);

            peter.Town = "Sofia";

            stella.Town = "Vidin";
            stella.Occupation = "gamer";
            stella.Result = Student.AcademyResult.High;

            Console.WriteLine(peter.Description);
            Console.WriteLine(stella.Description);

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}