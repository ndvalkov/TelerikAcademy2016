using System;

class IntDoubleAndString
{
    static void Main()
    {
        string typeOfInput = Console.ReadLine();
        string value = Console.ReadLine();

        switch (typeOfInput)
        {
            case "integer":
                int integer = int.Parse(value);
                Console.WriteLine(++integer);
                break;
            case "real":
                double real = double.Parse(value);
                Console.WriteLine("{0:0.00}", real += 1);
                break;
            case "text":
                Console.WriteLine(value + "*");
                break;
        }
    }
}