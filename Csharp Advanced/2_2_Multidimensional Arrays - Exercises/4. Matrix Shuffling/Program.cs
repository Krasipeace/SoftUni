using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long rows = input[0];
            long cols = input[1];
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
                if (tokens[0] == "swap")
                {
                    long posRowX = long.Parse(tokens[1]);
                    long posColX = long.Parse(tokens[2]);
                    long posRowY = long.Parse(tokens[3]);
                    long posColY = long.Parse(tokens[4]);

                    if (((posRowX >= 0 && posRowX < rows) && (posColX >= 0 && posColX < cols))
                     && ((posRowY >= 0 && posRowY < rows) && (posColY >= 0 && posColY < cols)))
                    {
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
