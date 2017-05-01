namespace RefactoringHomework.RotatingWalkInMatrix.Utils
{
    using System;
    using Contracts;

    public class MatrixConsole : IWriter
    {
        public void Write(string text)
        {
            Console.Write("{0,3}", text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}