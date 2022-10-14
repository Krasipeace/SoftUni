using System;
using System.Linq;

namespace _2.Garden //62/100 time limit reached
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[][] matrix = new int[matrixSize[0]][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i] = new int [matrixSize[1]];
            }

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int plantRow = int.Parse(tokens[0]);
                int plantCol = int.Parse(tokens[1]);

                if (int.Parse(tokens[0]) > matrix.Length  || int.Parse(tokens[0]) < 0 || int.Parse(tokens[1]) > matrix[plantRow].Length || int.Parse(tokens[1]) < 0)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                int currPos = matrix[plantRow][plantCol];

                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[0 + i][plantCol] += 1;
                }

                for (int i = 0; i < matrix[plantRow].Length; i++)
                {
                    matrix[plantRow][0 + i] += 1;
                }

                matrix[plantRow][plantCol] = currPos + 1;

                command = Console.ReadLine();
            }

            foreach (var flower in matrix)
            {
                Console.WriteLine(string.Join(" ", flower));
            }
        }
    }
}
