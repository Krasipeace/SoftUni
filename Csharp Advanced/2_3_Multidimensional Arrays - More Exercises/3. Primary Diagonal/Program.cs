using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = rows;
            int[,] matrix = new int[rows, cols];
            int diagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (row == col)
                    {
                        diagonalSum += matrix[row, col];
                    }
                }
            }            

            Console.WriteLine(diagonalSum);
        }
    }
}
