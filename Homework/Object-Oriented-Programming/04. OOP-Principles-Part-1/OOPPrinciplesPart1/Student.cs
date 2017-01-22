using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public class Student : Person, IComments
    {
        public Student(string name, int age) : base(name, age)
        {
        }

        public Student(string name, int age, int classId) : base(name, age)
        {
            ClassId = classId;
        }

        /// <summary>
        /// Unique class number
        /// </summary>
        public int ClassId { get; set; }
        public string Comments { get; set; }

        public void AddComment(string comment)
        {
            throw new NotImplementedException();
        }
    }
}