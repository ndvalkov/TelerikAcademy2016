using CohesionAndCoupling.Contracts;
using CohesionAndCoupling.Utils;

namespace CohesionAndCoupling.Models
{
    public class Cuboid : Figure3D, ICuboid
    {
        public Cuboid(double width, double height, double depth) : base(width, height, depth)
        {
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = MathUtils.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = MathUtils.CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = MathUtils.CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = MathUtils.CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}