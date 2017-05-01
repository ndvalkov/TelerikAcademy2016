using System;
using System.Collections.Generic;
using System.Text;
using InheritanceAndPolymorphism.Contracts;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, IList<string> students = null) :
            base(courseName, teacherName, students)
        {
        }

        public LocalCourse(string courseName, string teacherName, string lab, IList<string> students = null) :
            this(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid lab name argument");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            if (this.Lab != null)
            {
                sb.Append("; Lab = ");
                sb.Append(this.Lab);
            }
            
            sb.Append(" }");

            return sb.ToString();
        }
    }
}
