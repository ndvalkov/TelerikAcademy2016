using System;

class CheckForAPlayCard
{
    static void Main()
    {
        string card = Console.ReadLine();
        
      	bool isValidCard = true;

        switch (card)
        {
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                break;
            case "7":
                break;
            case "8":
                break;
            case "9":
                break;
            case "10":
                break;
            case "J":
                break;
            case "Q":
                break;
            case "K":
                break;
            case "A":
                break;
            default:
                isValidCard = false;
                break;
        }

        Console.WriteLine(isValidCard ? "yes {0}" : "no {0}", card);
    }
}