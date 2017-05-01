namespace RefactoringHomework.RotatingWalkInMatrix
{
    using Engine;

    public class Startup
    {
        public static void Main(string[] args)
        {
            /*MatrixConsole.WriteLine("Enter a positive number between 1 and 100: ");
            string input = MatrixConsole.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                MatrixConsole.WriteLine("You haven't entered a correct positive number");
                input = MatrixConsole.ReadLine();
            }*/

            MatrixEngine engine = MatrixEngine.Instance;
            engine.Size = 3;
            engine.Start();
        }
    }
}