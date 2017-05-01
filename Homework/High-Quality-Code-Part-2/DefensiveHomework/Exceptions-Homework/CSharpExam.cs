namespace Exceptions_Homework
{
    using System;

    public class CSharpExam : Exam
    {
        private const int MIN_SCORE = 0;
        private const int MAX_SCORE = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get { return this.score; }
            private set
            {
                if (value < MIN_SCORE || MAX_SCORE < value)
                {
                    throw new ArgumentOutOfRangeException($@"The c# score must be between ${MIN_SCORE} and ${MAX_SCORE}");
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            var examResult = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            return examResult;
        }
    }
}