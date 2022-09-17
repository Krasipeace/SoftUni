using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                double[] col = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
                jaggedArray[row] = col;
            }

            ManipulateEqualRows(rows, jaggedArray);

            UseCommands(jaggedArray);

            PrintResult(jaggedArray);
        }

        private static void ManipulateEqualRows(int rows, double[][] jaggedArray)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x * 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x * 2).ToArray();
                }
                else if (jaggedArray[row].Length != jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(y => y / 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(y => y / 2).ToArray();
                }
            }
        }

        private static void UseCommands(double[][] jaggedArray)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] input = command.Split(" ");
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray[row].Length))
                {
                    switch (input[0])
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static void PrintResult(double[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine($"{string.Join(" ", jaggedArray[i])}");
            }
        }
    }
}
