using Cooking.Contracts;

namespace Cooking.Veggies
{
    public class Carrot : Vegetable, ICarrot
    {
        public Carrot()
        {
        }

        public bool IsRotten { get; set; }
    }
}