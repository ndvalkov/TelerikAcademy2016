using System;
using System.Collections.Generic;

class SubStringInText
{
    static void Main()
    {
        string pattern = Console.ReadLine();
        string text = Console.ReadLine();

        text = text.ToLower();
        pattern = pattern.ToLower();

        int occurrences = text.Split(new string[] { pattern }, StringSplitOptions.None).Length - 1;

        Console.WriteLine(occurrences);
    }
}
