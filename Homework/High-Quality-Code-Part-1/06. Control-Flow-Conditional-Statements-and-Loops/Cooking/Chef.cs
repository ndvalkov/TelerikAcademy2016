using System;
using Cooking.Contracts;
using Cooking.Veggies;

namespace Cooking
{
    public class Chef
    {
        public void Cook()
        {
            IPotato potato = GetPotato();
            ICarrot carrot = GetCarrot();

            Peel(potato);
            Peel(carrot);

            Cut(potato);
            Cut(carrot);

            IBowl bowl = GetBowl();

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        public void Cook(IVegetable veggie)
        {
            if (veggie == null)
            {
                throw new ArgumentNullException();
            }

            Peel(veggie);
            Cut(veggie);

            IBowl bowl = GetBowl();

            bowl.Add(veggie);
        }

        private void Cut(IVegetable veggie)
        {
            //...
        }

        private void Peel(IVegetable veggie)
        {
            //...
        }

        private IPotato GetPotato()
        {
            return new Potato();
        }

        private IBowl GetBowl()
        {
            return new Bowl();
        }

        private ICarrot GetCarrot()
        {
            return new Carrot();
        }
    }
}
