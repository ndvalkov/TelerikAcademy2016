namespace RefactoringHomework.RotatingWalkInMatrix.Engine
{
    internal class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }
    }
}