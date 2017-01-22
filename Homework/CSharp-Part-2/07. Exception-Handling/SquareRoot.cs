using System;

class SquareRoot
{
    static void Main()
    {
        string input = Console.ReadLine();

        try
        {
            var result = double.Parse(input);

            if (result < 0)
            {
                throw new FormatException();
            }

            Console.WriteLine("{0:F3}", Math.Sqrt(result));
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine("Invalid number");
        }
        catch(FormatException ex)
        {
            Console.WriteLine("Invalid number");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Invalid number");
        }

        Console.WriteLine("Good bye");
    }
}