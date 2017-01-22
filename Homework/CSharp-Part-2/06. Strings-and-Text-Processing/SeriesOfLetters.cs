using System;
using System.Collections.Generic;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<char> result = new List<char>();
        result.Add(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            if (result[result.Count - 1] == input[i])
            {
                continue;
            }

            result.Add(input[i]);
        }

        Console.WriteLine(new string(result.ToArray()));
    }
}