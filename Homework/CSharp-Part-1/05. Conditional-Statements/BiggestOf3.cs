using System;

class BiggestOf3
{
    static void Main()
    {
        float firstNumber = float.Parse(Console.ReadLine());
        float secondNumber = float.Parse(Console.ReadLine());
        float thirdNumber = float.Parse(Console.ReadLine());

        float biggest = firstNumber;

        if (secondNumber > biggest)
        {
            biggest = secondNumber;
        }

        if (thirdNumber > biggest)
        {
            biggest = thirdNumber;
        }

        Console.WriteLine(biggest);
    }
}