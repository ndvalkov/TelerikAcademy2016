namespace AnimalHierarchy
{
   public abstract class Animal : ISound
    {
        protected Animal(int age, string name, Sex sex)
        {
            Age = age;
            Name = name;
            Sex = sex;
        }

        public int Age { get; private set; }
        public string Name { get; set; }
        public Sex Sex { get; private set; }

        public abstract void MakeSound();
    }
}
