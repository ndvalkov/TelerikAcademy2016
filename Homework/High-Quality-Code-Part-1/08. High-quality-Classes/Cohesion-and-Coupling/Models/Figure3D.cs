using System;
using CohesionAndCoupling.Contracts;

namespace CohesionAndCoupling.Models
{
    public abstract class Figure3D : IFigure3D
    {
        private double width;
        private double height;
        private double depth;

        protected Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public virtual double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width must be positive");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height must be positive");
                }

                this.height = value;
            }
        }

        public virtual double Depth
        {
            get { return this.depth; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The depth must be positive");
                }

                this.depth = value;
            }
        }
    }
}