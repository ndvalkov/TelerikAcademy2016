using System;

class TriangleSurface
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        // Triangle tr = new Triangle(a, b, c);
        // double result = Triangle.TriangleSurfaceCalculator.CalculateSurface(tr.SideA, tr.SideB, tr.SideC);

        double result = Triangle.TriangleSurfaceCalculator.CalculateSurface(a, b, c);

        Console.WriteLine("{0:F2}", result);
    }
}

class Shape
{
    public int X { get; private set; }
    public int Y { get; private set; }
}

class Triangle : Shape
{
    private double sideA;
    private double sideB;
    private double sideC;
    private double altitudeA;
    private double altitudeB;
    private double altitudeC;
    private double surface;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (!Validate(sideA, sideB, sideC))
        {
            throw new ArgumentException("Invalid triangle.");
        }

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        CalculateSurface();
        CalculateAltitudes();
    }

    public double SideA
    {
        get
        {
            return sideA;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid side value.");
            }

            sideA = value;
        }
    }

    public double SideB
    {
        get
        {
            return sideB;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid side value.");
            }

            sideB = value;
        }
    }

    public double SideC
    {
        get
        {
            return sideC;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid side value.");
            }

            sideC = value;
        }
    }

    public double AltitudeA { get; private set; }
    public double AltitudeB { get; private set; }
    public double AltitudeC { get; private set; }
    public double Surface { get; private set; }

    private void CalculateSurface()
    {
        surface = TriangleSurfaceCalculator.CalculateSurface(sideA, sideB, sideC);
    }

    private void CalculateAltitudes()
    {
        AltitudeA = 2 * (Surface / SideA);
        AltitudeB = 2 * (Surface / SideB);
        AltitudeC = 2 * (Surface / SideC);
    }

    public bool Validate(double sideA, double sideB, double sideC)
    {
        if ((sideA + sideB) > sideC && (sideA + sideC) > sideB && (sideB + sideC) > sideA)
        {
            return true;
        }

        return false;
    }

    public static class TriangleSurfaceCalculator
    {
        public static double CalculateSurface(Triangle tr)
        {
            return CalculateSurface(tr.SideA, tr.SideB, tr.SideC);
        }

        public static double CalculateSurface(double side, double altitude)
        {
            return (side * altitude) / 2.0;
        }

        public static double CalculateSurface(double a, double b, double c)
        {
            double i = (a + b + c) / 2.0;
            return Math.Sqrt(i * (i - a) * (i - b) * (i - c));
        }
    }
}