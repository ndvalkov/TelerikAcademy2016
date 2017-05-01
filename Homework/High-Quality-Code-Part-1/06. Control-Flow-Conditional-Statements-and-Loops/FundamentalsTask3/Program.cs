using System;

namespace FundamentalsTask3
{
    class SecretMessage
    {
        static void Main()
        {
            int lineNumber = 1;
            string end = "end";
            string hiddenMessage = "";

            while (true)
            {
                string start = Console.ReadLine();

                if (start == end)
                {
                    break;
                }

                int startPosition = int.Parse(start);
                int endOfSegment = int.Parse(Console.ReadLine());
                string nextLine = Console.ReadLine();

                if (startPosition < 0)
                {
                    startPosition = nextLine.Length + startPosition;
                }

                if (endOfSegment < 0)
                {
                    endOfSegment = nextLine.Length + endOfSegment;
                }

                int step = (lineNumber % 2 != 0) ? 3 : 4;

                hiddenMessage += nextLine[startPosition];
                for (int i = startPosition + step; i <= endOfSegment; i += step)
                {
                    hiddenMessage += nextLine[i];
                }

                lineNumber++;
            }

            Console.WriteLine(hiddenMessage);
        }
    }
}
