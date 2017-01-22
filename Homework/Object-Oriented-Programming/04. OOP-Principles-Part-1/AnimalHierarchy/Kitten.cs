using System;

namespace AnimalHierarchy
{
    class Kitten : Cat
    {
        public Kitten(int age, string name) : base(age, name, Sex.Female)
        {
        }

        public override void MakeSound()
        {
            base.MakeSound();
            Console.Beep(155, 1000);
        }
    }
}
