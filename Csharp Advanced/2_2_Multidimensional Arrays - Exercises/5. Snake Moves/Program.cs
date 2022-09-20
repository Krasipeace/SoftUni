using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(m => int.Parse(m)).ToArray();
            string snake = Console.ReadLine();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            char[,] matrix = new char[rows, cols];

            int currentSnakeIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (currentSnakeIndex == snake.Length)
                        {
                            currentSnakeIndex = 0;
                        }

                        matrix[row, col] = snake[currentSnakeIndex];

                        currentSnakeIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (currentSnakeIndex == snake.Length)
                        {
                            currentSnakeIndex = 0;
                        }

                        matrix[row, col] = snake[currentSnakeIndex];

                        currentSnakeIndex++;
                    }
                }
            }
            PrintResult(matrix);
        }

        static void PrintResult(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
