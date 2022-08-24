using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] col = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedArray[row] = col;
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] input = command.Split(" ");
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0 || col < 0 || row >= jaggedArray.Length || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (input[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (input[0] == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine($"{string.Join(" ", jaggedArray[i])}");
            }
        }
    }
}
