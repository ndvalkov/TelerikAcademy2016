using System;
using System.Collections.Generic;

class SequenceInMatrix
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] dimensions = input.Split(new char[] { ' ' });
        int N = int.Parse(dimensions[0]);
        int M = int.Parse(dimensions[1]);
        string[,] matrix = new string[N, M];

        // Initialize matrix
        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine();

            string[] elements = input.Split(new char[] { ' ' });

            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = elements[j];
            }
        }

        // DFS
        // https://zeroreversesoft.wordpress.com/2013/02/17/searching-for-the-largest-area-of-equal-elements-in-a-matrix-using-bfsdfs-hybrid-algorithm/
        bool[,] visitedCells = new bool[N, M];
        Stack<int> branchingCellRow = new Stack<int>();
        Stack<int> branchingCellCol = new Stack<int>();
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int maxSequenceLength = 0;
        int currentSequenceLength = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                string currentValue = matrix[row, col];
                bool isBranching = false;
                bool isVisited = visitedCells[row, col];

                if (col - 1 >= 0 && matrix[row, col - 1] == currentValue &&
                    visitedCells[row, col - 1] == false) // left
                {
                    isBranching = true;
                }
                else if (col + 1 < cols && matrix[row, col + 1] == currentValue &&
                    visitedCells[row, col + 1] == false) // right
                {
                    isBranching = true;
                }
                else if (row - 1 >= 0 && matrix[row - 1, col] == currentValue &&
                    visitedCells[row - 1, col] == false) // up
                {
                    isBranching = true;
                }
                else if (row + 1 < rows && matrix[row + 1, col] == currentValue &&
                    visitedCells[row + 1, col] == false) // down
                {
                    isBranching = true;
                }
                else if (col - 1 >= 0 && row - 1 >= 0 && matrix[row - 1, col - 1] == currentValue &&
                    visitedCells[row - 1, col - 1] == false) // left up
                {
                    isBranching = true;
                }
                else if (col + 1 < cols && row - 1 >= 0 && matrix[row - 1, col + 1] == currentValue &&
                    visitedCells[row - 1, col + 1] == false) //right up
                {
                    isBranching = true;
                }
                else if (col - 1 >= 0 && row + 1 < rows && matrix[row + 1, col - 1] == currentValue &&
                    visitedCells[row + 1, col - 1] == false) // left down
                {
                    isBranching = true;
                }
                else if (col + 1 < cols && row + 1 < rows && matrix[row + 1, col + 1] == currentValue &&
                    visitedCells[row + 1, col + 1] == false) // right down
                {
                    isBranching = true;
                }

                if (!isVisited && isBranching)
                {
                    branchingCellRow.Push(row);
                    branchingCellCol.Push(col);

                    while (branchingCellRow.Count > 0 && branchingCellRow.Count > 0)
                    {
                        row = branchingCellRow.Pop();
                        col = branchingCellCol.Pop();

                        int tempRow = row;
                        int tempCol = col;

                        // ---------- Vertical/Horizontal ------------

                        while (tempCol - 1 >= 0 && matrix[tempRow, tempCol - 1] == currentValue &&
                            visitedCells[tempRow, tempCol - 1] == false) // left
                        {
                            tempCol = tempCol - 1;
                            branchingCellRow.Push(tempRow);
                            branchingCellCol.Push(tempCol);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        while (tempCol + 1 < cols && matrix[tempRow, tempCol + 1] == currentValue &&
                            visitedCells[tempRow, tempCol + 1] == false) //right
                        {
                            tempCol = tempCol + 1;
                            branchingCellCol.Push(tempCol);
                            branchingCellRow.Push(tempRow);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        while (tempRow - 1 >= 0 && matrix[tempRow - 1, tempCol] == currentValue &&
                           visitedCells[tempRow - 1, tempCol] == false) //up
                        {
                            tempRow = tempRow - 1;
                            branchingCellCol.Push(tempCol);
                            branchingCellRow.Push(tempRow);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        while (tempRow + 1 < rows && matrix[tempRow + 1, tempCol] == currentValue &&
                            visitedCells[tempRow + 1, tempCol] == false) //down
                        {
                            tempRow = tempRow + 1;
                            branchingCellCol.Push(tempCol);
                            branchingCellRow.Push(tempRow);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        // ---------- Diagonals ------------

                        while (tempCol - 1 >= 0 && tempRow - 1 >= 0 
                            && matrix[tempRow - 1, tempCol - 1] == currentValue &&
                            visitedCells[tempRow - 1, tempCol - 1] == false) // left up
                        {
                            tempCol = tempCol - 1;
                            tempRow = tempRow - 1;
                            branchingCellRow.Push(tempRow);
                            branchingCellCol.Push(tempCol);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        while (tempCol + 1 < cols && tempRow - 1 >= 0 &&
                            matrix[tempRow - 1, tempCol + 1] == currentValue &&
                            visitedCells[tempRow - 1, tempCol + 1] == false) //right up
                        {
                            tempCol = tempCol + 1;
                            tempRow = tempRow - 1;
                            branchingCellCol.Push(tempCol);
                            branchingCellRow.Push(tempRow);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        while (tempRow + 1 < rows && tempCol - 1 >= 0 &&
                            matrix[tempRow + 1, tempCol - 1] == currentValue &&
                           visitedCells[tempRow + 1, tempCol - 1] == false) // left down
                        {
                            tempRow = tempRow + 1;
                            tempCol = tempCol - 1;
                            branchingCellCol.Push(tempCol);
                            branchingCellRow.Push(tempRow);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }

                        tempRow = row;
                        tempCol = col;

                        while (tempRow + 1 < rows && tempCol + 1 < cols &&
                            matrix[tempRow + 1, tempCol + 1] == currentValue &&
                            visitedCells[tempRow + 1, tempCol + 1] == false) //right down
                        {
                            tempRow = tempRow + 1;
                            tempCol = tempCol + 1;
                            branchingCellCol.Push(tempCol);
                            branchingCellRow.Push(tempRow);
                            visitedCells[tempRow, tempCol] = true;
                            currentSequenceLength++;
                        }
                    }

                    if (currentSequenceLength > maxSequenceLength)
                    {
                        maxSequenceLength = currentSequenceLength;
                    }

                    currentSequenceLength = 0;
                }
            }
        }

        Console.WriteLine(maxSequenceLength);
    }
}