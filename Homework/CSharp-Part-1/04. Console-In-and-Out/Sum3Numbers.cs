using System;

class SumOf3Numbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double sum = a + b + c;

        Console.WriteLine((sum % 1 == 0) ? (int) sum : sum);
    }
}