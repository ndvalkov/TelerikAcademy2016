using System;
using Methods.Contracts;

namespace Methods
{
    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string town;
        private AcademyResult academyResult;
        private string occupation;

        public enum AcademyResult
        {
            None,
            Low,
            Medium,
            High
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.town = string.Empty;
            this.academyResult = AcademyResult.None;
            this.occupation = string.Empty;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid argument");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid argument");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid argument");
                }

                this.town = value;
            }
        }

        public AcademyResult Result { get; set; }

        public string Occupation
        {
            get { return this.occupation; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid argument");
                }

                this.occupation = value;
            }
        }

        public string Description
        {
            get
            {
               var academyResult = (this.Result == AcademyResult.None)
                    ? string.Empty
                    : Enum.GetName(typeof(AcademyResult), this.Result).ToLower() + " results,";
                
                var birthDate = this.DateOfBirth.ToString("dd.MM.yyyy");
                var occupation = (this.Occupation == string.Empty) ? string.Empty : this.Occupation + ", ";

                var description = string.Format($"From {this.Town}, {occupation}{academyResult}born at {birthDate}.");
                return description;
            }
        }

        public bool IsOlderThan(IPerson other)
        {
            return this.DateOfBirth > other.DateOfBirth;
        }
    }
}