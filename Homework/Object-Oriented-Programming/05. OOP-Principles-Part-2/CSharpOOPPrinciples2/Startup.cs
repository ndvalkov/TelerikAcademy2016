using System;

namespace CSharpOOPPrinciples2
{
    class Startup
    {
        static void Main(string[] args)
        {
            try
            {
                // Tests
                Shape s1 = new Rectangle(2, 4);
                // Shape s2 = new Rectangle(-1, 11);
                // Shape s3 = new Rectangle(23, -4);
                Shape s4 = new Square(3, 3);
                // Shape s5 = new Square(0, 0);
                // Shape s6 = new Square(-4, -4);
                // Shape s7 = new Square(23, 23.1);
                // Shape s8 = new Triangle(0, 12);
                // Shape s9 = new Triangle(14, -4);
                Shape s10 = new Triangle(2, 4);

                Shape[] shapes = {s1, s4, s10};

                foreach (var shape in shapes)
                {
                    Console.Write("Surface of shape " + shape.GetType().ToString().Split('.')[1]);
                    Console.WriteLine(": " + shape.CalculateSurface());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
