using System;

namespace DefiningClasses
{
    public static class GeometryCalculator
    {
        public static double CalculateDistance(Point3D start, Point3D end)
        {
            double deltaX = end.X - start.X;
            double deltaY = end.Y - start.Y;
            double deltaZ = end.Z - start.Z;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

            return distance;
        }
    }
}