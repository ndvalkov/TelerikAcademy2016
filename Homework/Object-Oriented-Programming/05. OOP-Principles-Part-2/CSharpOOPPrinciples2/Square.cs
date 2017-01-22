using System;

namespace CSharpOOPPrinciples2
{
    class Square : Shape
    {
        public Square(double height, double width)
        {
            SimpleValidator.CheckNotPositive((decimal)height, "height");
            SimpleValidator.CheckNotPositive((decimal)width, "width");

            if (Math.Abs(height - width) > 0.001)
            {
                throw new ArgumentException("The sides of a square must be equal");
            }

            Height = height;
            Width = width;
        }

        public double Height { get; }
        public double Width { get; }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
