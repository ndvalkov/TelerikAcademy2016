using System;

namespace AnimalHierarchy
{
    class Cat : Animal
    {
        public Cat(int age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow-meow");
        }
    }
}
