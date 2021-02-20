using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class KnightsTour
    {
        public int[,] Board = new int[8, 8];
        public int Size = 8;

        private int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public KnightsTour()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Board[i, j] = -1;
                }
            }

            Board[0, 0] = 0;
            Print();
        }

        public bool Solve(int x, int y, int stepNumber)
        {
            if (stepNumber == Size * Size)
                return true;

            // iterate over possible next steps
            for (int i = 0; i < 8; i++)
            {
                var nextX = x + xMove[i];
                var nextY = y + yMove[i];
                if (IsStepPossible(nextX, nextY))
                {
                    Board[nextX, nextY] = stepNumber;
                    if (Solve(nextX, nextY, stepNumber + 1))
                    {
                        return true;
                    }
                    else
                    {
                        Board[nextX, nextY] = -1;
                    }
                }
            }

            return false;
        }

        private bool IsStepPossible(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size && Board[x, y] == -1;
        }

        public void Print()
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