using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Sudoku
    {
        public int[,] Grid { get; }
        public int Size { get; } = 9;

        public Sudoku()
        {
            Grid = new int[Size, Size];
            InitGrid();
        }

        private void InitGrid()
        {
            Grid[0, 0] = 3;
            Grid[0, 2] = 6;
            Grid[0, 3] = 5;
            Grid[0, 5] = 8;
            Grid[0, 6] = 4;
            Grid[1, 0] = 5;
            Grid[1, 1] = 2;
            Grid[3, 1] = 8;
            Grid[3, 2] = 7;
            Grid[3, 7] = 3;
            Grid[3, 8] = 1;
        }

        public bool SolveSudoku()
        {
            var row = 0;
            var col = 0;
            bool isSolved = true;

            // find first empty field
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j] == 0)
                    {
                        isSolved = false;
                        row = i;
                        col = j;
                        break;
                    }
                }

                if (!isSolved)
                    break;
            }

            if (isSolved)
                return true;

            for (int i = 1; i <= Size; i++)
            {
                if (CheckIfNumberIsAllowed(row, col, i))
                {
                    Grid[row, col] = i;
                    if (SolveSudoku())
                        return true;

                    Grid[row, col] = 0;
                }
            }

            return false;
        }

        private bool CheckIfNumberIsAllowed(int row, int column, int number)
        {
            return CheckRow(row, number) && CheckColumn(column, number) && CheckBox(row, column, number);
        }

        private bool CheckBox(int currentRow, int currentColumn, int numberToCheck)
        {
            int sqrt = (int)Math.Sqrt(Size);
            int boxRowStart = currentRow - currentRow % sqrt;
            int boxColStart = currentColumn - currentColumn % sqrt;

            for (int i = boxRowStart; i < boxRowStart + sqrt; i++)
            {
                for (int j = boxColStart; j < boxColStart + sqrt; j++)
                {
                    if (Grid[i, j] == numberToCheck)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckRow(int currentRow, int numberToCheck)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Grid[currentRow, i] == numberToCheck)
                    return false;
            }

            return true;
        }

        private bool CheckColumn(int currentColumn, int numberToCheck)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Grid[i, currentColumn] == numberToCheck)
                    return false;
            }

            return true;
        }

        public void PrintSudoku()
        {
            StringBuilder sb = new StringBuilder();

            // iterate over each row
            for (int r = 0; r < Size; r++)
            {
                // iterate over each column
                for (int c = 0; c < Size; c++)
                {
                    sb.Append($"{Grid[r, c]} ");

                    // after last column add separator and new line
                    if (c == Size - 1)
                    {
                        sb.Append("\n");
                    }
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}