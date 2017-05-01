using Cooking.Contracts;

namespace Cooking.Veggies
{
    public class Potato : Vegetable, IPotato
    {
        public Potato()
        {
            
        }

        public bool IsPeeled { get; set; }
        public bool IsRotten { get; set; }
    }
}