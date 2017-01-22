namespace StudentsAndWorkers
{
    class Student : Human
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            Grade = grade;
        }

        public int Grade { get; set; }
    }
}
