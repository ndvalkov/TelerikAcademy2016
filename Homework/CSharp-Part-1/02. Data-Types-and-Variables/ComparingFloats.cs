using System;

class ComparingFloats
{
    public static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        float eps = 0.000001f;

        if (Math.Abs(firstNumber - secondNumber) < eps)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}