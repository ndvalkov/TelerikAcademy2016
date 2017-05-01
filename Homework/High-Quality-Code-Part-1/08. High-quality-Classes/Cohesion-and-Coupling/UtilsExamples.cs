using System;
using CohesionAndCoupling.Contracts;
using CohesionAndCoupling.Models;
using CohesionAndCoupling.Utils;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                MathUtils.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                MathUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            ICuboid cuboid = new Cuboid(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", cuboid.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cuboid.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cuboid.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cuboid.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cuboid.CalculateDiagonalYZ());
        }
    }
}
