namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private const int MIN_PROBLEMS_SOLVED = 0;
        private const int MAX_PROBLEMS_SOLVED = 10;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get { return this.problemsSolved; }
            private set
            {
                if (value < MIN_PROBLEMS_SOLVED || MAX_PROBLEMS_SOLVED < value)
                {
                    throw new ArgumentOutOfRangeException($@"The problems solved must be 
                        between ${MIN_PROBLEMS_SOLVED} and ${MAX_PROBLEMS_SOLVED}");
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved == MIN_PROBLEMS_SOLVED)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved > MIN_PROBLEMS_SOLVED && this.ProblemsSolved < 4)
            {
                return new ExamResult(3, 2, 6, "Low result: few problems solved.");
            }
            else if (this.ProblemsSolved >= 4 && this.ProblemsSolved < 7)
            {
                return new ExamResult(4, 2, 6, "Average result: half problems solved.");
            }
            else if (this.ProblemsSolved >= 7 && this.ProblemsSolved < 9)
            {
                return new ExamResult(5, 2, 6, "Good result: most problems solved.");
            }
            else if (this.ProblemsSolved == 9 || this.ProblemsSolved == MAX_PROBLEMS_SOLVED)
            {
                return new ExamResult(6, 2, 6, "Excellent result: (almost)all solved.");
            }

            throw new InvalidOperationException("Invalid number of problems solved");
        }
    }
}