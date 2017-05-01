using System;
using System.Collections.Generic;
using System.Text;
using InheritanceAndPolymorphism.Contracts;

namespace InheritanceAndPolymorphism
{
    public abstract class Course : ICourse
    {
        private readonly IList<string> Students;

        private string courseName;
        private string teacherName;

        protected Course(string courseName, string teacherName, IList<string> students = null)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;

            if (students == null)
            {
                this.Students = new List<string>();
            }
            else
            {
                this.Students = students;
            }
        }

        protected string CourseName
        {
            get { return this.courseName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid course name argument");
                }

                this.courseName = value;
            }
        }

        protected string TeacherName
        {
            get { return this.teacherName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid teacher name argument");
                }

                this.teacherName = value;
            }
        }

        public string ListStudents()
        {
            if (this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }

        public void AddStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid student name argument");
            }

            this.Students.Add(name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.GetType().Name} {{ Name = ");
            sb.Append(this.CourseName);
            sb.Append("; Teacher = ");
            sb.Append(this.TeacherName);
            sb.Append("; Students = ");
            sb.Append(this.ListStudents());

            return sb.ToString();
        }
    }
}