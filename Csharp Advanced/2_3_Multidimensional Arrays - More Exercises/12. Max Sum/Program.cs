using System;
using System.Linq;

namespace _12._Max_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_SQUARE_ROWS = 3;
            const int MAX_SQUARE_COLUMNS = 3;

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
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
                        int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1] 
                                  + matrix[row + 2, col] + matrix[row, col + 2] + matrix[row + 2, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 1];

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxRowIndex = row;
                            maxColIndex = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRowIndex; row < maxRowIndex + MAX_SQUARE_ROWS; row++)
            {
                for (int cow = maxColIndex; cow < maxColIndex + MAX_SQUARE_COLUMNS; cow++)
                {
                    Console.Write($"{matrix[row, cow]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
