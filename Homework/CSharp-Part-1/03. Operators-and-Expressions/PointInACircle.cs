using System;

class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double radius = 2;

        double distance = Math.Sqrt(x * x + y * y);

        Console.WriteLine((distance <= radius) ?
                          String.Format("yes {0:0.00}", distance) :
                          String.Format("no {0:0.00}", distance));
    }
}