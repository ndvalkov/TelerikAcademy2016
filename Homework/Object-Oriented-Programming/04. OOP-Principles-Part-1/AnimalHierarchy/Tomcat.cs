using System;

namespace AnimalHierarchy
{
    class Tomcat : Cat
    {
        public Tomcat(int age, string name) : base(age, name, Sex.Male)
        {
            
        }

        public override void MakeSound()
        {
            base.MakeSound();
            Console.Beep(550, 500);
        }
    }
}
