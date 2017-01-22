using System;

class SpiralMatrix
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[,] spiralMatrix = new int[N, N];

        // boundaries of the matrix
        int topBorder = 0;
        int leftBorder = 0;
        int rightBorder = N - 1;
        int bottomBorder = N - 1;

        int currentValue = 1;
        int currentRow = 0;
        int currentCol = 0;

        bool isFirstSpiral = true;
        int counter = 0;

        while (counter < N * N)
        {
            spiralMatrix[currentRow, currentCol] = currentValue;

            int rowStep = 0;
            int colStep = 0;

            // top border movement
            if (currentRow == topBorder && currentCol != rightBorder)
            {
                // top left corner; don't shift border at first spiral
                if (currentCol == leftBorder && !isFirstSpiral)
                {
                    // bottom border is already filled, and safe to shift in
                    bottomBorder--;
                }
                
                colStep++;
            }

            // right border movement
            if (currentCol == rightBorder && currentRow != bottomBorder)
            {
                // top right corner; don't shift border at first spiral
                if (currentRow == topBorder && !isFirstSpiral)
                {
                    // left border is already filled, and safe to shift in
                    leftBorder++;
                }

                rowStep++;
            }

            // bottom border movement
            if (currentRow == bottomBorder && currentCol != leftBorder) 
            {
                // bottom right corner
                if (currentCol == rightBorder)
                {
                    // top border is already filled, and safe to shift in
                    topBorder++; 
                }

                colStep--;
            }

            // left border movement
            if (currentCol == leftBorder && currentRow != topBorder) 
            {
                // bottom left corner
                if (currentRow == bottomBorder)
                {
                    // right border is already filled, and safe to shift in
                    rightBorder--;
                }

                isFirstSpiral = false;
                rowStep--;
            }

            currentCol += colStep;
            currentRow += rowStep;
            currentValue++;
            counter++;
        }

        // print matrix
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(string.Format("{0} ", spiralMatrix[i, j]));
            }

            Console.Write('\n');
        }
    }
}