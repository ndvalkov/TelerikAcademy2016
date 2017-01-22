using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace ExtensionsDelegatesLambda
{
    class Startup
    {
        static void Main()
        {
            // 1. Test SubString extension methods
            StringBuilder sb = new StringBuilder("Pesho");
            string result = sb.SubString(0, 2);
            Console.WriteLine(result);

            Console.WriteLine(new string('-', 23));

            // 2. Test Aggregate extension methods
            int[] testInstance1 = {21, 11, 16, 14, 42, 15, 3, 7};
            List<int> testInstance2 = new List<int>(new[] {-23, 11, 1, -44, int.MinValue});
            List<int> testInstance3 = new List<int>(new[] {int.MaxValue, 11, 1});
            double[] testInstance4 = {2, 2, 2, 4};

            Console.WriteLine("Sum: " + ExtensionMethods.Sum(testInstance3));
            Console.WriteLine("Product: " + testInstance4.Product());
            Console.WriteLine("Min: " + ExtensionMethods.Min(testInstance2));
            Console.WriteLine("Max: " + ExtensionMethods.Max(testInstance2));
            Console.WriteLine("Avg: " + ExtensionMethods.Average(testInstance1));

            Console.WriteLine(new string('-', 23));

            // 3. Test first before last
            Student[] students =
            {
                new Student("Pesho", "Ivanov", 23),
                new Student("Stamat", "Petrov", 35),
                new Student("Tsetska", "Dimitrova", 18),
                new Student("Angelina", "Tsvetanova", 25),
                new Student("Angelina", "Zlatanova", 25)
            };

            Console.WriteLine(students
                .Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(students.SortFirstNameBeforeLast()
                .Select(st => st.FirstName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 4. Test age range
            Console.Write("Age range(18 - 24): ");
            Console.WriteLine(students
                .Where(st => st.Age >= 18 && st.Age <= 24)
                .Select(st => st.FirstName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 5. Test age range

            Student[] studentsSortedDesc = students
                .OrderBy(st => st.FirstName, new DescComparer())
                .ThenBy(st => st.LastName, new DescComparer())
                .ToArray();

            Console.Write("Sorted(Lambda): ");
            Console.WriteLine(studentsSortedDesc
                .Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.Write("Sorted(LINQ): ");

            var studentsSortedD =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine(studentsSortedD
                .Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 6. Test divisible by 7 and 3
            IEnumerable<int> resLambda = testInstance1.Where(item => item % 3 == 0 && item % 7 == 0);
            Console.Write("Div 7 and 3(Lambda): ");
            Console.WriteLine(resLambda.Print());

            var resLINQ =
                from item in testInstance1
                where item % 3 == 0 && item % 7 == 0
                select item;

            Console.Write("Div 7 and 3(LINQ): ");
            Console.WriteLine(resLINQ.Print());

            Console.WriteLine(new string('-', 23));

            // 7. Test Timer

            Console.WriteLine("Timer delegate logic commented out.");
            // UNCOMMENT TO TEST
            /*PrintDelegate pd = PrintCollection;
            MyTimer mt = new MyTimer();
            mt.Start(1000, testInstance1, pd);*/

            Console.WriteLine(new string('-', 23));

            // 8. Test Events

            Console.WriteLine("Timer event logic commented out.");
            // UNCOMMENT TO TEST
            /*MyTimer mt = new MyTimer();
            mt.OnElapsed += OnTimerElapsed;
            mt.StartWithEvent(1000, testInstance1);*/

            Console.WriteLine(new string('-', 23));

            // 9. Test Student Groups
            Student pesho = new Student("Petur", "Jones", 23, "666212", "0987231111", "pesho@abv.bg", 2);
            Student katya = new Student("Katya", "Moore", 19, "221345", "0886231612", "katya@gmail.com", 1);
            Student dimi = new Student("Dimitur", "Storarov", 25, "109433", "0986233711", "dimi@hotmail.com", 2);
            Student susan = new Student("Susan", "Ivanova", 22, "231306", "0987261611", "susi.sexa@abv.bg", 3);
            Student stamat = new Student("Stamat", "Evlogiev", 19, "111106", "0786111618", "stamchu@gmail.com", 1);
            Student haigu = new Student("Haigashot", "Azaryan", 24, "432206", "02833331", "aza.batman@gmail.com", 2);

            pesho.AddMarks(new[] {2, 5, 5, 6});
            katya.AddMarks(new[] {4, 5, 4, 3});
            dimi.AddMarks(new[] {3, 3, 2, 2});
            susan.AddMarks(new[] {4, 5, 5, 5});
            stamat.AddMarks(new[] {6, 5, 5, 6});
            haigu.AddMarks(new[] {2, 5, 5, 6});

            List<Student> newStudents = new List<Student>(new[] {pesho, katya, dimi, susan, stamat, haigu});

            var studentsFromSecondGroup = newStudents.Where(st => st.GroupNumber == 2);

            var sortedByFirstName = from student in studentsFromSecondGroup
                orderby student.FirstName
                select student;

            Console.Write("Sorted from group 2(LINQ): ");
            Console.WriteLine(sortedByFirstName.Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 10. Test Student Groups extensions
            var sortedWithExt = newStudents
                .Where(st => st.GroupNumber == 2)
                .OrderBy(st => st.FirstName);

            Console.Write("Sorted from group 2(Ext): ");
            Console.WriteLine(sortedWithExt.Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 11. Extract students by email

            var studentsWithAbvEmail = newStudents.Where(st => st.Email.IndexOf("abv.bg", StringComparison.Ordinal) >= 0);

            Console.Write("With abv.bg address: ");
            Console.WriteLine(studentsWithAbvEmail.Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 12. Extract students by Sofia phones

            var studentsWithSofiaPhones = newStudents.Where(st => st.Tel.Substring(0, 2).Equals("02"));

            Console.Write("With Sofia tels: ");
            Console.WriteLine(studentsWithSofiaPhones.Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 13. Extract students by marks

            var studentsByMarks = newStudents
                .Where(st => st.Marks.IndexOf("6", StringComparison.Ordinal) >= 0)
                .Select(st => new
                {
                    FullName = st.FirstName + " " + st.LastName,
                    Marks = st.Marks
                });

            studentsByMarks.ToList().ForEach(st => Console.WriteLine(st.FullName + " | " + st.Marks));

            Console.WriteLine(new string('-', 23));

            // 14. Extract students with two marks
            var studentsWithTwo2 = newStudents.Where(st => st.Marks.Count(ch => ch == '2') == 2);

            Console.Write("With two 2's: ");
            Console.WriteLine(studentsWithTwo2.Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 15. 2006
            var studentsOf2006 = newStudents.Where(st => st.FN[4] == '0' && st.FN[5] == '6');

            Console.Write("Sudents enrolled in 2006: ");
            Console.WriteLine(studentsOf2006.Select(st => st.FirstName + " " + st.LastName)
                .ToArray()
                .Print());

            Console.WriteLine(new string('-', 23));

            // 16. Groups Join
            var groups = new List<Group>();
            groups.Add(new Group {GroupNumber = 1, DepartmentName = "English"});
            groups.Add(new Group {GroupNumber = 2, DepartmentName = "Mathematics"});
            groups.Add(new Group {GroupNumber = 3, DepartmentName = "Literature"});
            groups.Add(new Group {GroupNumber = 4, DepartmentName = "Physics"});

            var innerGroupJoinQuery =
                from st in newStudents
                join gr in groups on st.GroupNumber equals gr.GroupNumber
                where gr.DepartmentName == "Mathematics"
                select new {FullName = st.FirstName + " " + st.LastName, Dept = gr.DepartmentName};

            Console.WriteLine("Sudents from Mathematics Dep: ");
            Console.WriteLine(innerGroupJoinQuery.Select(st => st.FullName + " | " + st.Dept + Environment.NewLine)
                .ToArray()
                .Print(""));

            Console.WriteLine(new string('-', 23));
            // 17. Longest string

            string[] names = {"pesho", "katya", "dimi", "susan", "stavri kalinov", "stamat", "haigu"};
            var maxLengthStr = names.OrderByDescending(st => st.Length).First();
            Console.WriteLine("Str with max length: " + maxLengthStr);

            Console.WriteLine(new string('-', 23));
            // 18. Grouped by GroupNumber
            var results = from st in newStudents
                group st by st.GroupNumber
                into g
                orderby g.Key
                select new {Group = g.Key, Students = g.ToList()};

            foreach (var res in results)
            {
                Console.Write("Group " + res.Group + ": ");
                res.Students.ForEach(st => Console.Write(st.FirstName + " " + st.LastName + ", "));
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine(new string('-', 23));
            // 19. Grouped by GroupNumber with extension methods
            var groupedWithExt = newStudents.GroupBy(st => st.GroupNumber,
                (key, g) => new
                {
                    Group = key,
                    Students = g.ToList()
                }
            ).OrderBy(g => g.Group);

            foreach (var item in groupedWithExt)
            {
                Console.Write("Group " + item.Group + ": ");
                item.Students.ForEach(st => Console.Write(st.FirstName + " " + st.LastName + ", "));
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 23));
            // 20. Infinite convergent series
            Console.WriteLine("{0:0.00}", Sum(m => 1 / (decimal)Math.Pow(2, m - 1)));
            Console.WriteLine("{0:0.00}", Sum(m => 1m / Enumerable.Range(1, m).Aggregate((a, b) => a * b)));
            Console.WriteLine("{0:0.00}", Sum(m => -1 / (decimal)Math.Pow(-2, m - 1)));

        }

        private static void PrintCollection<T>(IEnumerable<T> list)
        {
            Console.WriteLine(list.Print());
        }

        private static void OnTimerElapsed(object sender, EventArgs eventArgs)
        {
            PrintCollection(((MyTimer) sender).ListOfInts);
        }

        private static decimal Sum(Func<int, decimal> f)
        {
            decimal sum = 1;
            for (int i = 2; Math.Abs(f(i)) > 0.001m; i++)
            {
                sum += f(i);
            }
                
            return sum;
        }
    }
}