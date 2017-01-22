using System;

class PrintADeck
{
    static void Main()
    {
        // 10?
        // char cardSign = char.Parse(Console.ReadLine());
        String cardSign = Console.ReadLine();

        String signs = "2345678910JQKA";

        int position = signs.IndexOf(cardSign);
        for (int i = 0; i <= position; i++)
        {
            if (i == signs.IndexOf("10"))
            {
                Console.WriteLine("10 of spades, 10 of clubs, 10 of hearts, 10 of diamonds ");
                i++;
            }
            else
            {
                Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds ",
                signs[i]);
            }
        }
    }
}