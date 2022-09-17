using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputRowsCols = int.Parse(Console.ReadLine());

            long[,] matrix = new long[inputRowsCols, inputRowsCols];
            long firstDiagonalSum = 0;
            long secondDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                long[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            for (int row = 0; row < inputRowsCols; row++)
            {
                firstDiagonalSum += matrix[row, row];
            }

            for (int row = 0, col = inputRowsCols - 1; row < inputRowsCols; row++, col--)
            {
                secondDiagonalSum += matrix[row, col];
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
