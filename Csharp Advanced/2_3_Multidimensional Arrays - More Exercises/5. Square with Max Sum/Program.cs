using System;
using System.Linq;

namespace _5._Square_with_Max_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_SQUARE_ROWS = 2;
            const int MAX_SQUARE_COLUMNS = 2;

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + MAX_SQUARE_ROWS - 1 < rows && col + MAX_SQUARE_COLUMNS - 1 < cols)
                    {
                        int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxRowIndex = row;
                            maxColIndex = col;
                        }
                    }
                }
            }

            for (int row = maxRowIndex; row < maxRowIndex + MAX_SQUARE_ROWS; row++)
            {
                for (int cow = maxColIndex; cow < maxColIndex + MAX_SQUARE_COLUMNS; cow++)
                {
                    Console.Write($"{matrix[row, cow]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
