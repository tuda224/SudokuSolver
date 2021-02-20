using System;

namespace SudokuSolver
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //var sudoku = new Sudoku();
            //sudoku.SolveSudoku();
            //sudoku.PrintSudoku();

            //var nqueen = new NQueen();
            //nqueen.Solve(0);
            //nqueen.PrintBoard();

            //var knightsTour = new KnightsTour();
            //knightsTour.Solve(0, 0, 1);
            //knightsTour.Print();

            var rat = new RatInAMaze();
            rat.Solve(0, 0);
            rat.Print();
            Console.ReadLine();
        }
    }
}