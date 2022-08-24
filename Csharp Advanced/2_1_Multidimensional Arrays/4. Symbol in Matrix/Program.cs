using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[inputSize, inputSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isSymbolFound = false;

            for (int row = 0; row < inputSize; row++)
            {
                for (int col = 0; col < inputSize; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");                         
                        
                        return;
                    }
                }
            }

            if (!isSymbolFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
