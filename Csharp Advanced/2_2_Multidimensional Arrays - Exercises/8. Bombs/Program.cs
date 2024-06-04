using System;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] bombsPos = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombsPos.Length; i++)
            {
                int[] tokens = bombsPos[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(t => int.Parse(t)).ToArray();
                int row = tokens[0];
                int col = tokens[1];

                BombExplosion(matrix, row, col);
            }

            int aliveCells = 0;
            int sumOfCells = 0;

            CalculateCellsData(matrixSize, matrix, ref aliveCells, ref sumOfCells);

            PrintResults(matrixSize, matrix, aliveCells, sumOfCells);
        }

        static void BombExplosion(int[,] matrix, int row, int col)
        {
            int bombStrength = matrix[row, col];

            if (bombStrength > 0)
            {
                matrix[row, col] = 0; //boom mid

                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                if (row > 0 && matrix[row - 1, col] > 0)  //boom up
                {
                    matrix[row - 1, col] -= bombStrength;
                }
                if (row < rows - 1 && matrix[row + 1, col] > 0)  //boom down
                {
                    matrix[row + 1, col] -= bombStrength;
                }
                if (col > 0 && matrix[row, col - 1] > 0) //boom left
                {
                    matrix[row, col - 1] -= bombStrength;
                }
                if (col < cols - 1 && matrix[row, col + 1] > 0) //boom right
                {
                    matrix[row, col + 1] -= bombStrength;
                }

                if (row > 0 && col > 0 && matrix[row - 1, col - 1] > 0) //boom up left
                {
                    matrix[row - 1, col - 1] -= bombStrength;
                }
                if (row > 0 && col < cols - 1 && matrix[row - 1, col + 1] > 0) //boom up right
                {
                    matrix[row - 1, col + 1] -= bombStrength;
                }
                if (row < rows - 1 && col > 0 && matrix[row + 1, col - 1] > 0) //boom down left
                {
                    matrix[row + 1, col - 1] -= bombStrength;
                }
                if (row < rows - 1 && col < cols - 1 && matrix[row + 1, col + 1] > 0) //boom down right
                {
                    matrix[row + 1, col + 1] -= bombStrength;
                }
            }
        }

        static void CalculateCellsData(int matrixSize, int[,] matrix, ref int aliveCells, ref int sumOfCells)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumOfCells += matrix[row, col];
                    }
                }
            }
        }

        static void PrintResults(int matrixSize, int[,] matrix, int aliveCells, int sumOfCells)
        {
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
