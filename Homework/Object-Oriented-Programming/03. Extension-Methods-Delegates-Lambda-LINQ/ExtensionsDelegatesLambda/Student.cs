using System;
using System.Collections.Generic;
using DefiningClasses;
using Extensions;

namespace ExtensionsDelegatesLambda
{
    class Student : Person
    {
        private List<int> marks;

        public string FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int? GroupNumber { get; set; }

        public string Marks
        {
            get { return string.Join(", ", marks); }
        }

        public Student(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            marks = new List<int>();
        }

        public Student(string firstName, string lastName, int age, string fn, string tel, string email, int groupNumber)
            : this(firstName, lastName, age)
        {
            FN = fn;
            Tel = tel;
            Email = email;
            GroupNumber = groupNumber;
        }

        public void AddMark(int mark)
        {
            if (mark < 2 || mark > 6)
            {
                throw new ArgumentException("Invalid mark for the student");
            }

            marks.Add(mark);
        }

        public void AddMarks(int[] markGroup)
        {
            SimpleValidator.CheckNull(markGroup, "Marks argument");

            foreach (var mark in markGroup)
            {
                if (mark < 2 || mark > 6)
                {
                    throw new ArgumentException("Invalid mark for the student");
                }

                marks.Add(mark);
            }
        }
    }
}