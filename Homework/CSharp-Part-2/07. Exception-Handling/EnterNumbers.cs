using System;
using System.Collections.Generic;

class EnterNumbers
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        string separator = " < ";

        List<int> sequence = new List<int>();
        
        int currentNumber = 1; // constraint min
        
        try
        {
            sequence.Add(start);

            while (true)
            {
                var nextNumber = ReadNumber(start, end);

                if (nextNumber <= currentNumber)
                {
                    throw new InvalidOperationException("Exception");
                }

                currentNumber = nextNumber;
                sequence.Add(currentNumber);

                if (sequence.Count == 11) // 10 + start
                {
                    break;
                }
            }

            sequence.Add(end);

            Console.WriteLine(string.Join(separator, sequence));
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();
        double result;

        bool parsed = double.TryParse(input, out result);

        if (!parsed || (result % 1 != 0))
        {
            throw new FormatException("Exception");
        }

        return Convert.ToInt32(result);
    }
}