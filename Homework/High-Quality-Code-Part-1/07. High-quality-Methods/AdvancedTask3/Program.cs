using System;
using System.Text;

namespace AdvancedTask3
{
    class SnackyTheSnake
    {
        private const char ROCK_SYMBOL = '#';
        private const char ENTRANCE_SYMBOL = 's';
        private const char SPACE_SYMBOL = '.';
        private const char FOOD_SYMBOL = '*';
        private const string LEFT = "l";
        private const string RIGHT = "r";
        private const string DOWN = "d";
        private const string UP = "u";
        private const char DIM_SPLIT_SEPARATOR = 'x';
        private const char DIR_SPLIT_SEPARATOR = ',';

        private static string[] denGrid = {};
        private static string[] directions = {};
        private static int snackyLength = 3;
        private static int allowedMoves = 5;
        private static int rows;
        private static int cols;

        public static void Main()
        {
            var input = ReadInput();
            var dims = Split(input, DIM_SPLIT_SEPARATOR);

            rows = ParseInt(dims[0]);
            cols = ParseInt(dims[1]);

            denGrid = new string[rows];

            for (var i = 0; i < rows; i++)
            {
                denGrid[i] = ReadInput();
            }

            directions = Split(input, DIR_SPLIT_SEPARATOR);
            TraverseDen(denGrid);
            // RemoveFoodFromGrid(1, 4, denGrid);
            // Console.WriteLine();
        }

        private static string[] Split(string input, char separator)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Parse input cannot be null or empty");
            }

            string[] result = input.Split(new[] { separator }, StringSplitOptions.None);
            return result;
        }

        private static string ReadInput()
        {
            string input = null;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please, enter some input value.");
                }
                else
                {
                    break;
                }
            } while (true);

            return input;
        }

        private static int ParseInt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Parse input cannot be null or empty");
            }

            try
            {
                var result = int.Parse(input);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format of the input");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too big");
                throw;
            }
        }

        // ####s###
        // ....*...
        // ..*.....
        // .....*..
        // ..###...

        private static void TraverseDen(string[] den)
        {
            int entrance = FindEntrance(denGrid[0]);
            string currentDirection;
            int currentRow = 0;
            int currentCol = entrance;

            for (int i = 0; i < directions.Length; i++)
            {
                currentDirection = directions[i];

                UpdateAllowedMoves();

                if (snackyLength == 0)
                {
                    // starve in the den
                    Console.WriteLine("Snacky will starve at [{0},{1}]", currentRow, currentCol);
                    return;
                }

                if (currentDirection == DOWN)
                {
                    if (currentRow + 1 == rows)
                    {
                        //  lost into the depths
                        Console.WriteLine("Snacky will be lost into the depths with length {0}",
                            snackyLength);
                        return;
                    }

                    currentRow++;

                    // extract in a method
                    if (denGrid[currentRow][currentCol] == FOOD_SYMBOL)
                    {
                        EatFood();
                        RemoveFoodFromGrid(currentRow, currentCol, den);
                    }

                    if (denGrid[currentRow][currentCol] == ROCK_SYMBOL)
                    {
                        // hit rock
                        Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                        return;
                    }
                }

                if (currentDirection == RIGHT)
                {
                    if (currentCol == cols - 1)
                    {
                        // move to left side
                        currentCol = 0;
                    }
                    else
                    {
                        currentCol++;

                        if (denGrid[currentRow][currentCol] == FOOD_SYMBOL)
                        {
                            EatFood();
                            RemoveFoodFromGrid(currentRow, currentCol, den);
                        }

                        if (denGrid[currentRow][currentCol] == ROCK_SYMBOL)
                        {
                            // hit rock
                            Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                            return;
                        }
                    }
                }

                if (currentDirection == LEFT)
                {
                    if (currentCol == 0)
                    {
                        // move to right side
                        currentCol = cols - 1;
                    }
                    else
                    {
                        currentCol--;

                        if (denGrid[currentRow][currentCol] == FOOD_SYMBOL)
                        {
                            EatFood();
                            RemoveFoodFromGrid(currentRow, currentCol, den);
                        }

                        if (denGrid[currentRow][currentCol] == ROCK_SYMBOL)
                        {
                            // hit rock
                            Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                            return;
                        }
                    }
                }

                if (currentDirection == UP)
                {
                    currentRow--;

                    if (den[currentRow][currentCol] == ENTRANCE_SYMBOL)
                    {
                        // successfully exit
                        Console.WriteLine("Snacky will get out with length {0}", snackyLength);
                        return;
                    }

                    if (denGrid[currentRow][currentCol] == FOOD_SYMBOL)
                    {
                        EatFood();
                        RemoveFoodFromGrid(currentRow, currentCol, den);
                    }

                    if (denGrid[currentRow][currentCol] == ROCK_SYMBOL)
                    {
                        // hit rock
                        Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                        return;
                    }
                }
            }

            Console.WriteLine("Snacky will be stuck in the den at [{0},{1}]", currentRow, currentCol);
        }

        private static void RemoveFoodFromGrid(int row, int col, string[] grid)
        {
            if (grid == null)
            {
                throw new ArgumentNullException("The value of the grid parameter cannot be null");
            }

            string currentRow = grid[row];
            StringBuilder sb = new StringBuilder(currentRow);

            sb.Replace(FOOD_SYMBOL, SPACE_SYMBOL, col, 1);

            grid[row] = sb.ToString();
        }

        private static void UpdateAllowedMoves()
        {
            allowedMoves--;
            if (allowedMoves == 0)
            {
                snackyLength--;
                allowedMoves = 5;
            }
        }

        private static void EatFood()
        {
            snackyLength++;
        }

        private static int FindEntrance(string firstRow)
        {
            if (string.IsNullOrWhiteSpace(firstRow))
            {
                throw new ArgumentException("First row cannot be null or empty");
            }

            return firstRow.IndexOf(ENTRANCE_SYMBOL);
        }
    }
}