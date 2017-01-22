using System;
using System.Collections.Generic;

class CorrectBrackets
{
    static void Main()
    {
        string input = Console.ReadLine();
        char opening = '(';
        char closing = ')';
        Stack<char> brackets = new Stack<char>();
        bool areBracketsCorrect = true;

        for (int i = 0; i < input.Length; i++)
        {
            char currentSymbol = input[i];
            if (currentSymbol == opening)
            {
                brackets.Push(currentSymbol);
            }

            if (currentSymbol == closing)
            {
                if (brackets.Count == 0)
                {
                    areBracketsCorrect = false;
                    break;
                }
                else
                {
                    brackets.Pop();
                }
            }
        }

        if (brackets.Count > 0)
        {
            areBracketsCorrect = false;
        }

        Console.WriteLine(areBracketsCorrect ? "Correct" : "Incorrect");
    }
}