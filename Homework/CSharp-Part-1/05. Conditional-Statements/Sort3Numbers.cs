using System;

class Sort3Numbers
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber >= secondNumber && firstNumber >= thirdNumber) // first biggest
        {
            Console.Write(firstNumber + " ");

            if (secondNumber >= thirdNumber)
            {
                Console.Write(secondNumber + " " + thirdNumber);
            }
            else
            {
                Console.Write(thirdNumber + " " + secondNumber);
            }

        }
        else if (secondNumber >= firstNumber && secondNumber >= thirdNumber) // second biggest
        {
            Console.Write(secondNumber + " ");

            if (firstNumber >= thirdNumber)
            {
                Console.Write(firstNumber + " " + thirdNumber);
            }
            else
            {
                Console.Write(thirdNumber + " " + firstNumber);
            }
        }
        else // third biggest
        {
            Console.Write(thirdNumber + " ");

            if (firstNumber >= secondNumber)
            {
                Console.Write(firstNumber + " " + secondNumber);
            }
            else
            {
                Console.Write(secondNumber + " " + firstNumber);
            }
        }
    }
}