using System;
using System.Collections.Generic;

class FillTheMatrix
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        char modifier = char.Parse(Console.ReadLine());

        int[,] numbers = new int[N, N];

        int row = 0;
        int col = 0;
        int counter = 1;

        switch(modifier) {
            case 'a':
                for (row = 0; row < N; row++)
                {
                    for (col = 0; col < N; col++)
                    {
                        numbers[col, row] = counter++;
                    }
                }

                break;
            case 'b':
                for (row = 0; row < N; row++)
                {
                    if (row % 2 == 0)
                    {
                        for (col = 0; col < N; col++)
                        {
                            numbers[col, row] = counter++;
                        }
                    }
                    else
                    {
                        for (col = N - 1; col >= 0; col--)
                        {
                            numbers[col, row] = counter++;
                        }
                    }
                }

                break;
            case 'c':
                int startRow = N - 1;
                int startCol = 0;
                int diagonalCells = 1;

                for (int i = 0; i < N + N; i++)
                {
                    row = startRow;
                    col = startCol;

                    for (int j = 1; j <= diagonalCells; j++) {
                        numbers[row, col] = counter++;
                        row++;
                        col++;
                    }

                    if (startRow == 0)
                    {
                        diagonalCells--;
                        startCol++;
                    }
                    else
                    {
                        diagonalCells++;
                        startRow--;
                    }
                }

                break;
            case 'd':
                // http://www.introprogramming.info/tag/spiral-matrix/
                int positionX = N / 2; // The middle of the matrix
                int positionY = N % 2 == 0 ? (N / 2) - 1 : (N / 2);

                int direction = 0; // The initial direction is "down"
                int stepsCount = 1; // Perform 1 step in current direction
                int stepPosition = 0; // 0 steps already performed
                int stepChange = 0; // Steps count changes after 2 steps

                for (int i = N * N; i > 0; i--)
                {
                    // Fill the current cell with the current value
                    numbers[positionY, positionX] = i;

                    // Check for direction / step changes
                    if (stepPosition < stepsCount)
                    {
                        stepPosition++;
                    }
                    else
                    {
                        stepPosition = 1;
                        if (stepChange == 1)
                        {
                            stepsCount++;
                        }
                        stepChange = (stepChange + 1) % 2;
                        direction = (direction + 1) % 4;
                    }

                    // Move to the next cell in the current direction
                    switch (direction)
                    {
                        case 0:
                            positionY++;
                            break;
                        case 1:
                            positionX--;
                            break;
                        case 2:
                            positionY--;
                            break;
                        case 3:
                            positionX++;
                            break;
                    }
                }

                break;
        }

        printMatrix(numbers);
    }

    public static void printMatrix(int[,] matrix) {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            List<int> row = new List<int>();
            for (int j = 0; j < matrix.GetLength(1); j++) {
                row.Add(matrix[i, j]);
            }

            Console.WriteLine(string.Join(" ", row));
        }
    }
}