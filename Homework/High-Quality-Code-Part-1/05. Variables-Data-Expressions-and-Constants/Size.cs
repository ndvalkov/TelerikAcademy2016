using System;

namespace VariablesHomework
{
    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public static Size GetRotatedSize(Size size, double rotationAngle)
        {
            var angleSin = Math.Sin(rotationAngle);
            var angleCos = Math.Cos(rotationAngle);

            var sinWidth = Math.Abs(angleSin) * size.Width;
            var cosWidth = Math.Abs(angleCos) * size.Width;
            var sinHeight = Math.Abs(angleSin) * size.Height;
            var cosHeight = Math.Abs(angleCos) * size.Height;

            var result = new Size(cosWidth + sinHeight, sinWidth + cosHeight);

            return result;
        }
    }
}