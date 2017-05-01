using System;
using Abstraction.Contracts;

namespace Abstraction
{
    abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateSurface();
    }
}
