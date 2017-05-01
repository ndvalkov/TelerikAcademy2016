using System;
using System.Collections.Generic;
using System.Text;
using InheritanceAndPolymorphism.Contracts;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, IList<string> students = null) :
            base(courseName, teacherName, students)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, string town, IList<string> students = null) :
            this(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid town name argument");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            if (this.Town != null)
            {
                sb.Append("; Town = ");
                sb.Append(this.Town);
            }
            
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
