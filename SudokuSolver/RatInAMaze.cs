using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class RatInAMaze
    {
        public int[,] Board { get; set; }
        public int[,] SolutionPath { get; set; }
        public int Size { get; set; }

        private int[] moveX = { 1, 0 };
        private int[] moveY = { 0, 1 };

        public RatInAMaze()
        {
            Size = 5;
            Board = new int[,] {
                {1, 0, 0, 0, 0},
                {1, 1, 1, 1, 1},
                {0, 0, 0, 1, 1},
                {1, 1, 1, 0, 1},
                {1, 1, 1, 1, 1}
            };
            SolutionPath = new int[Size, Size];
            SolutionPath[0, 0] = 1;
        }

        public bool Solve(int x, int y)
        {
            if (x == Size - 1 && y == Size - 1)
                return true;

            for (int i = 0; i < moveX.Length; i++)
            {
                var nextX = x + moveX[i];
                var nextY = y + moveY[i];

                if (StepPossible(nextX, nextY))
                {
                    SolutionPath[nextX, nextY] = 1;
                    if (Solve(nextX, nextY))
                    {
                        return true;
                    }
                    else
                    {
                        SolutionPath[nextX, nextY] = 0;
                    }
                }
            }

            return false;
        }

        private bool StepPossible(int nextX, int nextY)
        {
            return nextX < Size && nextY < Size && Board[nextX, nextY] == 1;
        }

        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append($"{SolutionPath[i, j]} ");
                }
                sb.Append($"\n");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}