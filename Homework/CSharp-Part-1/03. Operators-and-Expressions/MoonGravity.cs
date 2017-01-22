using System;

class MoonGravity
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());
        float moonGravityModifier = 0.17f;
        Console.WriteLine("{0:0.000}", weight * moonGravityModifier);
    }
}