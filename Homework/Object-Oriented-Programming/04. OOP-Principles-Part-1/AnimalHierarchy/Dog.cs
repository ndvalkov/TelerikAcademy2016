using System;

namespace AnimalHierarchy
{
    class Dog : Animal
    {
        public Dog(int age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            Console.Write("Bow-bow");
        }
    }
}
