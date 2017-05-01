using System;
using CohesionAndCoupling.Contracts;

namespace CohesionAndCoupling.Models
{
    public class Point3D : IPoint3D
    {
        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X
        {
            get { return this.x; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The X coordinate must be positive");
                }

                this.x = value;
            }
        }

        public double Y
        {
            get { return this.y; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The Y coordinate must be positive");
                }

                this.y = value;
            }
        }

        public double Z
        {
            get { return this.z; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The Z coordinate must be positive");
                }

                this.z = value;
            }
        }
    }
}