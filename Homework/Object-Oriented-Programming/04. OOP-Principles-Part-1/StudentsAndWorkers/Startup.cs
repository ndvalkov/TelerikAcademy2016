using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsAndWorkers
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Initialize a list of 10 students and sort them by grade in ascending order 
            // (use LINQ or OrderBy() extension method)

            Random rnd = new Random();

            IList<Student> students = new List<Student>();

            string[] firstNames = {"Koceto", "Kalina", "Stanislava", "George", "Yanko", "Nikolai"};
            string[] lastNames = {"Ivanova", "Smith", "Popov", "Nakov", "Telerikov", "Ivanov"};

            for (int i = 0; i < 10; i++)
            {
                string firstName = firstNames[rnd.Next(0, firstNames.Length)];
                string lastName = lastNames[rnd.Next(0, firstNames.Length)];
                int grade = rnd.Next(2, 7);

                students.Add(new Student(firstName, lastName, grade));
            }

            int listItemNumber = 0;

            foreach (var student in students.OrderBy(st => st.Grade))
            {
                Console.Write(++listItemNumber);
                Console.Write(". ");
                Console.WriteLine(student.FirstName + " " +
                                  student.LastName +
                                  ", " + "grade: " + student.Grade);
            }

            Console.WriteLine();

            // Initialize a list of 10 workers and sort them by money per hour in descending order.
            IList<Worker> workers = new List<Worker>();
            for (int i = 0; i < 10; i++)
            {
                string name = firstNames[rnd.Next(0, firstNames.Length)] +
                              " " +
                              lastNames[rnd.Next(0, firstNames.Length)];
                string firstName = firstNames[rnd.Next(0, firstNames.Length)];
                string lastName = lastNames[rnd.Next(0, firstNames.Length)];
                decimal weekSalary = rnd.Next(200, 600);
                int workHoursPerDay = rnd.Next(5, 10);

                workers.Add(new Worker(firstName, lastName, weekSalary, workHoursPerDay));
            }

            listItemNumber = 0;

            foreach (var worker in workers.OrderByDescending(w => w.MoneyPerHour()))
            {
                Console.Write(++listItemNumber);
                Console.Write(". ");

                var moneyPerHour = worker.MoneyPerHour();
                if (moneyPerHour != null)
                    Console.WriteLine(worker.FirstName +
                                      " " +
                                      worker.LastName +
                                      ", " +
                                      "mph: " +
                                      decimal.Round(moneyPerHour.Value));
            }

            Console.WriteLine();

            // Merge the lists and sort them by first name and last name.
            IList<Human> studentsAsHumans = new List<Human>(students);
            IList<Human> workersAsHumans = new List<Human>(workers);

            IEnumerable<Human> allHumans = studentsAsHumans.Concat(workersAsHumans);

            IList<Human> finalList = allHumans
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToList();

            Console.WriteLine("Sorted by first and last name: ");
            foreach (var human in finalList)
            {
                Console.Write(human.FirstName + " " + human.LastName + "\r\n");
            }

            Console.WriteLine();
        }
    }
}