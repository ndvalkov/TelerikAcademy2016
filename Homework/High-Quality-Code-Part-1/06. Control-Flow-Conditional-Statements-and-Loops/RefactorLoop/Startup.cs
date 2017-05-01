using System;
using System.Linq;

namespace RefactorLoop
{
    class Startup
    {
        static void Main()
        {
            var isValueFound = false;
            var expectedValue = 23;

            var Min = 1;
            var Max = 100;

            Random randNum = new Random();
            var numbers = Enumerable
                .Repeat(0, 100)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);

                if (i % 10 == 0)
                {
                    if (numbers[i] == expectedValue)
                    {
                        isValueFound = true;
                    }
                }
            }

            // More code here

            if (isValueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
