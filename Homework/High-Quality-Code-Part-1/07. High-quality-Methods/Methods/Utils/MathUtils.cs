using System;
using System.Linq;

namespace Methods.Utils
{
    public static class MathUtils
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("Invalid argument");
            }
        }

        public static int FindMax(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Invalid argument");
            }

            var result = numbers.Max();
            return result;
        }

        public static bool IsHorizontalDistance(Point from, Point to)
        {
            var result = (Math.Abs(from.Y - to.Y) < 0.0001);
            return result;
        }

        public static bool IsVerticalDistance(Point from, Point to)
        {
            var result = (Math.Abs(from.X - to.X) < 0.0001);
            return result;
        }

        public static double CalculateDistance(Point from, Point to)
        {
            double distance = Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y));
            return distance;
        }

        public class Point
        {
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }
        }
    }
}