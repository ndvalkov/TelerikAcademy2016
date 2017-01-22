using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long firstNumber = 0;
        long secondNumber = 1;

        int counter = 1;
        Console.Write("{0}, {1}, ", firstNumber, secondNumber);
        counter += 2;

        while (counter <= n) {
            long currentNumber = firstNumber + secondNumber;
            Console.Write(currentNumber);
            Console.Write((counter == n) ? "" : ", ");

            firstNumber = secondNumber;
            secondNumber = currentNumber;
            counter++;
        }
    }
}