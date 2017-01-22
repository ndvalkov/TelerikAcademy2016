using System;

namespace AnimalHierarchy
{
    class Frog : Animal
    {
        public Frog(int age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Frog music");
        }
    }
}
