using Cooking.Contracts;

namespace Cooking.Veggies
{
    public abstract class Vegetable : IVegetable
    {
        protected Vegetable()
        {
        }

        public bool IsRotten { get; set; }
    }
}