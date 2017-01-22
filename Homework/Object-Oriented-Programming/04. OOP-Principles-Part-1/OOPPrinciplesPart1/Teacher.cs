using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public class Teacher : Person, IComments
    {
        public Teacher(string name, int age) : base(name, age)
        {
        }

        public Teacher(string name, int age, List<SchoolDiscipline> disciplines) : base(name, age)
        {
            Disciplines = disciplines;
        }

        public List<SchoolDiscipline> Disciplines { get; set; }
        public string Comments { get; set; }

        public void AddComment(string comment)
        {
            throw new NotImplementedException();
        }
    }
}