using System;

class Rectangles
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double area = width * height;
        double perimeter = (width + height) * 2;

        Console.Write("{0:0.00} {1:0.00}", area, perimeter);
    }
}