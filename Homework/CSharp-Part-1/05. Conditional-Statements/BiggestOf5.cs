using System;

class BiggestOf5
{
    static void Main()
    {
        float firstNumber = float.Parse(Console.ReadLine());
        float secondNumber = float.Parse(Console.ReadLine());
        float thirdNumber = float.Parse(Console.ReadLine());
        float fourthNumber = float.Parse(Console.ReadLine());
        float fifthNumber = float.Parse(Console.ReadLine());

        float biggest = firstNumber;

        if (secondNumber > biggest)
        {
            biggest = secondNumber;
        }

        if (thirdNumber > biggest)
        {
            biggest = thirdNumber;
        }

        if (fourthNumber > biggest)
        {
            biggest = fourthNumber;
        }

        if (fifthNumber > biggest)
        {
            biggest = fifthNumber;
        }

        Console.WriteLine(biggest);
    }
}