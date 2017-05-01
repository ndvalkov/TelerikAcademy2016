namespace RotatingWalkInMatrix.Tests.MatrixEngineTests.Mocks
{
    using System;
    using System.IO;
    using RefactoringHomework.RotatingWalkInMatrix.Contracts;

    public class FileConsole : IWriter, IDisposable
    {
        private readonly StreamWriter sw;

        public FileConsole(string fileName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                FileStream fs = File.OpenWrite(path + '\\' + fileName);
                this.sw = new StreamWriter(fs);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to open the test file", e);
            }
        }

        public void Write(string text)
        {
           this.sw.Write($"{text,3}");
        }

        public void WriteLine(string text)
        {
            this.sw.WriteLine(text);
        }

        public void Dispose()
        {
            this.sw?.Dispose();
        }
    }
}