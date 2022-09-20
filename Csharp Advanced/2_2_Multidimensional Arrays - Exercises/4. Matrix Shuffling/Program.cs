using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "swap"
                    && tokens.Length == 5
                    && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < rows
                    && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < cols
                    && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < rows
                    && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < cols)
                {
                    int posRowX = int.Parse(tokens[1]);
                    int posColX = int.Parse(tokens[2]);
                    int posRowY = int.Parse(tokens[3]);
                    int posColY = int.Parse(tokens[4]);

                    string temp = matrix[posRowX, posColX];
                    matrix[posRowX, posColX] = matrix[posRowY, posColY];
                    matrix[posRowY, posColY] = temp;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }
    }
}

