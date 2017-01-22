using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public class SchoolDiscipline : SchoolEntity, IComments
    {
        public SchoolDiscipline(string name) : base(name)
        {
        }

        public SchoolDiscipline(string name, int numberOfLectures, int numberOfExcericises) : base(name)
        {
            NumberOfLectures = numberOfLectures;
            NumberOfExcericises = numberOfExcericises;
        }

        public int NumberOfLectures { get; set; }
        public int NumberOfExcericises { get; set; }
        public string Comments { get; set; }

        public void AddComment(string comment)
        {
            throw new NotImplementedException();
        }
    }
}