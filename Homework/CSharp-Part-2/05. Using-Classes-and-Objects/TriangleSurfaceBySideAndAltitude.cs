using System;

class TriangleSurface
{
    static void Main()
    {
        double sideLengh = double.Parse(Console.ReadLine());
        double altitude = double.Parse(Console.ReadLine());
        Triangle triangle = new Triangle();
        triangle.SideLength = sideLengh;
        triangle.Altitude = altitude;

        Console.WriteLine("{0:F2}", CalculateSurface(triangle));
    }

    private static double CalculateSurface(Triangle tr)
    {
        return (tr.SideLength * tr.Altitude) / 2.0;
    }
}

class Shape
{
    public int X { get; private set; }
    public int Y { get; private set; }
}

class Triangle : Shape
{
    public double SideLength { get; set; }
    public double Altitude { get; set; }
}