using System;

class SayHello
{
    static void Main()
    {
        string name = Console.ReadLine();
        printName(name);
    }

    static void printName(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}