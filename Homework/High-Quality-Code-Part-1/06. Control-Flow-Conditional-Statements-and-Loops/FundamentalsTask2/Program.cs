using System;
namespace FundamentalsTask2
{
    class GoingToAParty
    {
        static void Main()
        {
            string directions = Console.ReadLine();

            string alpha = "0abcdefghijklmnopqrstuvwxyz";
            char partySymbol = '^';
            string partyMsg = " Djor and Djano are at the party at {0}!";
            string lostMsg = "Djor and Djano are lost at {0}!";

            int currentPosition = 0;

            while (true)
            {
                char currentLetter = directions[currentPosition];
                int currentStep = alpha.IndexOf(char.ToLower(currentLetter));

                if (currentLetter == partySymbol)
                {
                    Console.WriteLine(partyMsg, currentPosition);
                    break;
                }

                if (char.IsUpper(currentLetter))
                {
                    currentPosition -= currentStep;
                }
                else
                {
                    currentPosition += currentStep;
                }

                if (currentPosition < 0 || currentPosition >= directions.Length)
                {
                    Console.WriteLine(lostMsg, currentPosition);
                    break;
                }
            }
        }
    }
}
