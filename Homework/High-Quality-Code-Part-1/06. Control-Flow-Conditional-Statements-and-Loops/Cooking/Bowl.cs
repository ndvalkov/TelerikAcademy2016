using System;
using System.Collections;
using System.Collections.Generic;
using Cooking.Contracts;

namespace Cooking
{
    public class Bowl : IBowl
    {
        private ICollection<IVegetable> veggies;

        public Bowl()
        {
            veggies = new List<IVegetable>();
        }

        public void Add(IVegetable veggie)
        {
            if (veggie == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            this.veggies.Add(veggie);
        }
    }
}