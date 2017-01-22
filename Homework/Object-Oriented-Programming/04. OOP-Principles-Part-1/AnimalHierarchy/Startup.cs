using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHierarchy
{
    class Startup
    {
        static void Main(string[] args)
        {
            // new Tomcat(12, "").MakeSound();
            // new Kitten(12, "").MakeSound();

            Animal animal1 = new Cat(5, "Kaloianka", Sex.Female);
            Animal animal2 = new Cat(10, "Evgeniq", Sex.Female);
            Animal animal3 = new Cat(9, "Pesho", Sex.Male);
            Animal animal4 = new Frog(12, "Stavri", Sex.Male);
            Animal animal5 = new Frog(2, "Petka", Sex.Female);
            Animal animal6 = new Dog(3, "Nikoleta", Sex.Female);
            Animal animal7 = new Dog(42, "OldDog", Sex.Male);
            Animal animal8 = new Dog(3, "Harry", Sex.Male);
            Animal animal9 = new Kitten(12, "Stanka");
            Animal animal10 = new Kitten(3, "Petranka");
            Animal animal11 = new Kitten(2, "Nakovka");
            Animal animal12 = new Tomcat(4, "Tom");
            Animal animal13 = new Tomcat(6, "Thomas");
            Animal animal14 = new Tomcat(7, "Tommy");
            Animal animal15 = new Tomcat(2, "Toma");

            Animal[] animalKingdom = new []
            {
                animal1,
                animal2,
                animal3,
                animal4,
                animal5,
                animal6,
                animal7,
                animal8,
                animal9,
                animal10,
                animal11,
                animal12,
                animal13,
                animal14,
                animal15
            };

            var results = animalKingdom
                .GroupBy(an => an.GetType())
                .Select(g => new
                {
                    Average = g.Average(a => a.Age),
                    g.Key
                });

            foreach (var result in results)
            {
                Console.Write(result.Key);
                Console.Write(": Average age ");
                Console.WriteLine(result.Average);
            }
        }
    }
}
