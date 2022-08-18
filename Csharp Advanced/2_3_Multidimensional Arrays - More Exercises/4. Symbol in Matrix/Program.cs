using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputRowsCols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[inputRowsCols, inputRowsCols];

            for (int row = 0; row < inputRowsCols; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            bool isSymbolFound = false;

            for (int row = 0; row < inputRowsCols; row++)
            {
                for (int col = 0; col < inputRowsCols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isSymbolFound = true;

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
