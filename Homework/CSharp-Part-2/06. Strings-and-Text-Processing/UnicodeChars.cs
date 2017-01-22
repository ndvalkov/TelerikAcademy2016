using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        var sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            sb.Append(GetEscapeSequence(input[i]));
        }

        Console.WriteLine(sb.ToString());
    }

    static string GetEscapeSequence(char c)
    {
        return "\\u" + ((int)c).ToString("X4");
    }
}