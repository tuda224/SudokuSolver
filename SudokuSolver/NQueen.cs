using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class NQueen
    {
        public int[,] Board { get; set; } = new int[4, 4];
        public int Size { get; set; } = 4;

        public bool Solve(int currentColumn)
        {
            if (currentColumn >= Size)
                return true;

            // try rows in current column
            for (int i = 0; i < Size; i++)
            {
                if (CanBePlacedInRow(i, currentColumn))
                {
                    Board[i, currentColumn] = 1;
                    if (Solve(currentColumn + 1))
                        return true;

                    Board[i, currentColumn] = 0;
                }
            }

            return false;
        }

        public bool CanBePlacedInRow(int row, int column)
        {
            // check row
            for (int i = 0; i < column; i++)
            {
                if (Board[row, i] == 1)
                    return false;
            }

            // check upper left
            for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (Board[i, j] == 1)
                    return false;
            }

            // check lower left
            for (int i = row, j = column; j >= 0 && i < Size; i++, j--)
            {
                if (Board[i, j] == 1)
                    return false;
            }

            return true;
        }

        public void PrintBoard()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append($"{Board[i, j]} ");
                }
                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}