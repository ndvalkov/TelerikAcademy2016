using System;

class Circle
{
    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        double area = Math.PI * radius * radius;
        double perimeter = 2 * Math.PI * radius;
        Console.Write("{0:0.00} ", perimeter);
        Console.Write("{0:0.00} ", area);
    }
}