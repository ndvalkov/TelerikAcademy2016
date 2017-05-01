using InheritanceAndPolymorphism.Contracts;
using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    class CoursesExamples
    {
        static void Main()
        {
            ILocalCourse localCourse = new LocalCourse("Databases", "Svetlin Nakov", new List<string>() { "Peter", "Maria" });
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";

            Console.WriteLine(localCourse);

            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");

            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
