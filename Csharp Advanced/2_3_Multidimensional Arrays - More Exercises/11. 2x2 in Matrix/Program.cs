using System;
using System.Linq;

namespace _11._2x2_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_SQUARE_ROWS = 2;
            const int MAX_SQUARE_COLUMNS = 2;

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + MAX_SQUARE_ROWS - 1 < rows && col + MAX_SQUARE_COLUMNS - 1 < cols)
                    {
                        char symbol = matrix[row, col];
                        if (matrix[row, col] == symbol && matrix[row, col + 1] == symbol && matrix[row + 1, col] == symbol && matrix[row + 1,col + 1] == symbol)
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
