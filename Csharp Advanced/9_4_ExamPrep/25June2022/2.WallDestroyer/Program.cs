using System;
using System.Linq;

namespace _2.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char VANKO_POS = 'V';
            const char ELECTRICITY_POS = 'E';
            const char HOLE_POS = '*';
            const char RODS_POS = 'R';
            const char CABLES_POS = 'C';
            const char EMPTY_POS = '-';

            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == VANKO_POS)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            bool isElectrocuted = false;
            int holes = 1;
            int rods = 0;
            matrix[currentRow, currentCol] = HOLE_POS;

            string command = Console.ReadLine();
            while (command != "End")
            {
                int pastRow = currentRow;
                int pastCol = currentCol;

                switch (command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }

                if (currentRow >= 0 && currentCol >= 0 && currentRow < matrixSize && currentCol < matrixSize)
                {
                    if (matrix[currentRow, currentCol] == RODS_POS)
                    {
                        rods++;
                        currentRow = pastRow;
                        currentCol = pastCol;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[currentRow, currentCol] == EMPTY_POS)
                    {
                        holes++;
                        matrix[currentRow, currentCol] = HOLE_POS;
                    }
                    else if (matrix[currentRow, currentCol] == HOLE_POS)
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }
                    else if (matrix[currentRow, currentCol] == CABLES_POS)
                    {
                        holes++;
                        matrix[currentRow, currentCol] = ELECTRICITY_POS;
                        isElectrocuted = true;
                        break;
                    }
                }
                else
                {
                    currentRow = pastRow;
                    currentCol = pastCol;
                }
                command = Console.ReadLine();
            }
            PrintResults(matrixSize, matrix, currentRow, currentCol, VANKO_POS, isElectrocuted, holes, rods);
        }
        static void PrintResults(int matrixSize, char[,] matrix, int currentRow, int currentCol, char VANKO_POS, bool isElectrocuted, int holes, int rods)
        {
            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
                matrix[currentRow, currentCol] = VANKO_POS;
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
