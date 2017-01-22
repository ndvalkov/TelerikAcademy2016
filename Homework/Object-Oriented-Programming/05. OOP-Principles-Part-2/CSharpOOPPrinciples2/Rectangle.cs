using System;

namespace CSharpOOPPrinciples2
{
    class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            SimpleValidator.CheckNotPositive((decimal)height, "height");
            SimpleValidator.CheckNotPositive((decimal)width, "width");

            this.Height = height;
            this.Width = width;
        }

        public double Height { get; }
        public double Width { get; }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
