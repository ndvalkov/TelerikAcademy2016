using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public class SchoolClass : SchoolEntity, IComments
    {
        public SchoolClass(string name) : base(name)
        {
        }

        public SchoolClass(string name, string identifier, List<Teacher> teachers, List<Student> students) : base(name)
        {
            Identifier = identifier;
            Teachers = teachers;
            Students = students;
        }

        /// <summary>
        /// Unique class identifier
        /// </summary>
        public string Identifier { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public string Comments { get; set; }

        public void AddComment(string comment)
        {
            throw new NotImplementedException();
        }
    }
}