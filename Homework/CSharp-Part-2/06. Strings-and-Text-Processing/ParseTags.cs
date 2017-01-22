using System;
using System.Collections.Generic;

class ParseTags
{
    static void Main()
    {
        string text = Console.ReadLine();
        string opening = "<upcase>";
        string closing = "</upcase>";

        string[] replaced = text.Split(new string[] { opening, closing }, StringSplitOptions.None);


        for (int i = 1; i < replaced.Length; i += 2)
        {
            replaced[i] = replaced[i].ToUpper();
        }

        Console.WriteLine(string.Join("", replaced));
    }
}