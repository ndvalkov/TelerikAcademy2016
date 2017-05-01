using System;
using Cooking.Contracts;
using Cooking.Veggies;

namespace Cooking
{
    public class Startup
    {
        const int ROWS = 3;
        const int COLS = 3;
        const int MIN_ROW = 0;
        const int MAX_ROW = ROWS - 1;
        const int MIN_COL = 0;
        const int MAX_COL = COLS - 1;

        private static int currentRow = 2;
        private static int currentCol = 2;

        public static void Main()
        {
            // TASK 2

            IPotato potato = new Potato();
            Chef chef = new Chef();

            if (potato != null)
            {
                if (!potato.IsRotten && potato.IsPeeled)
                {
                    chef.Cook(potato);
                }
            }

            // -----

            if (IsInColRange() && IsInRowRange() && !IsVisited())
            {
                VisitCell();
            }
        }


        private static bool IsInColRange()
        {
            bool result = MIN_COL <= currentCol && currentCol <= MAX_COL;

            return result;
        }

        private static bool IsInRowRange()
        {
            bool result = MIN_ROW <= currentRow && currentRow <= MAX_ROW;

            return result;
        }

        private static void VisitCell()
        {
            Console.WriteLine("I am in a cell now.");
        }

        private static bool IsVisited()
        {
            return false;
        }
    }
}