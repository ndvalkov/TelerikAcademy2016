namespace RefactoringHomework.RotatingWalkInMatrix.Engine
{
    using System;
    using Contracts;
    using Utils;

    public class MatrixEngine : IEngine
    {
        private const int MIN_SIZE = 1;
        private const int NUMBER_OF_DIRS = 8;

        public static MatrixEngine Instance { get; } = new MatrixEngine();

        private IWriter matrixConsole;
        private int size;

        private MatrixEngine()
        {
            this.MatrixConsole = new MatrixConsole();
            this.Size = MIN_SIZE;
        }

        public IWriter MatrixConsole
        {
            get { return this.matrixConsole; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The matrix console cannot be null");
                }

                this.matrixConsole = value;
            }
        }

        public int Size
        {
            get { return this.size; }
            set
            {
                if (value < MIN_SIZE)
                {
                    throw new ArgumentOutOfRangeException($"The size of the matrix cannot be less than {MIN_SIZE}");
                }

                this.size = value;
            }
        }

        public void Start()
        {
            var matrix = new int[this.size, this.size];
            var currentNumber = 1;
            var currentRow = 0;
            var currentCol = 0;
            var deltaX = 1;
            var deltaY = 1;

            do
            {
                matrix[currentRow, currentCol] = currentNumber;

                if (!this.HasFreeCells(matrix, currentRow, currentCol))
                {
                    currentNumber++;

                    var freeCell = this.FindFreeCell(matrix);
                    if (freeCell != null)
                    {
                        currentRow = freeCell.Row;
                        currentCol = freeCell.Col;
                        deltaX = 1;
                        deltaY = 1;
                        continue;
                    }

                    break;
                }

                while (this.IsOutsideRows(currentRow, deltaX) ||
                       this.IsOutsideCols(currentCol, deltaY) ||
                       matrix[currentRow + deltaX, currentCol + deltaY] != 0)
                {
                    this.ChangeDelta(ref deltaX, ref deltaY);
                }

                currentRow += deltaX;
                currentCol += deltaY;
                currentNumber++;
            } while (true);

            this.PrintMatrix(matrix);
        }

        private bool IsOutsideRows(int row, int delta)
        {
            var isOut = row + delta >= this.size || row + delta < 0;
            return isOut;
        }

        private bool IsOutsideCols(int col, int delta)
        {
            var isOut = col + delta >= this.size || col + delta < 0;
            return isOut;
        }

        private void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.MatrixConsole.Write(matrix[i, j].ToString());
                }

                this.MatrixConsole.WriteLine(string.Empty);
            }
        }

        private void ChangeDelta(ref int dx, ref int dy)
        {
            int[] deltasX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] deltasY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int changeDir = 0;
            for (int i = 0; i < NUMBER_OF_DIRS; i++)
            {
                if (deltasX[i] == dx && deltasY[i] == dy)
                {
                    changeDir = i;
                    break;
                }
            }

            if (changeDir == NUMBER_OF_DIRS - 1)
            {
                dx = deltasX[0];
                dy = deltasY[0];
                return;
            }

            dx = deltasX[changeDir + 1];
            dy = deltasY[changeDir + 1];
        }

        private bool HasFreeCells(int[,] matrix, int row, int col)
        {
            int[] deltasX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] deltasY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < NUMBER_OF_DIRS; i++)
            {
                if (this.IsOutsideRows(row, deltasX[i]))
                {
                    deltasX[i] = 0;
                }

                if (this.IsOutsideCols(col, deltasY[i]))
                {
                    deltasY[i] = 0;
                }

                if (matrix[row + deltasX[i], col + deltasY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private Cell FindFreeCell(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return null;
        }
    }
}