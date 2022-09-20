using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int minerStartRow = 0;
            int minerStartCol = 0;
            int countCoals = 0;
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ReadFieldSize(matrixSize, matrix, ref minerStartRow, ref minerStartCol, ref countCoals);

            int currentRow = minerStartRow;
            int currentCol = minerStartCol;

            MinerMovingInCells(matrixSize, matrix, ref countCoals, commands, ref currentRow, ref currentCol);

            PrintResults(matrix, countCoals, currentRow, currentCol);
        }

        static void ReadFieldSize(int matrixSize, char[,] matrix, ref int minerStartRow, ref int minerStartCol, ref int countCoals)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => char.Parse(i)).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    switch (input[col])
                    {
                        case 'c':  //coal cell
                            countCoals++;
                            break;
                        case 's':  //start cell
                            minerStartRow = row;
                            minerStartCol = col;
                            break;
                    }
                    matrix[row, col] = input[col];
                }
            }
        }

        private static void MinerMovingInCells(int matrixSize, char[,] matrix, ref int countCoals, string[] commands, ref int currentRow, ref int currentCol)
        {
            foreach (string action in commands)
            {
                bool isEnd = false;
                switch (action)
                {
                    case "up":
                        if (currentRow > 0)
                        {
                            currentRow--;
                            isEnd = InitializeMoveInCell(currentRow, currentCol, ref countCoals, matrix);
                        }
                        break;
                    case "down":
                        if (currentRow < matrixSize - 1)
                        {
                            currentRow++;
                            isEnd = InitializeMoveInCell(currentRow, currentCol, ref countCoals, matrix);
                        }
                        break;
                    case "left":
                        if (currentCol > 0)
                        {
                            currentCol--;
                            isEnd = InitializeMoveInCell(currentRow, currentCol, ref countCoals, matrix);
                        }
                        break;
                    case "right":
                        if (currentCol < matrixSize - 1)
                        {
                            currentCol++;
                            isEnd = InitializeMoveInCell(currentRow, currentCol, ref countCoals, matrix);
                        }
                        break;
                }
                if (isEnd)
                {
                    break;
                }
            }
        }

        static bool InitializeMoveInCell(int row, int col, ref int countCoals, char[,] matrix)
        {
            switch (matrix[row, col])
            {
                case 'e': //trap cell
                    return true;
                case 'c': //coal cell
                    matrix[row, col] = '*';
                    countCoals--;
                    if (countCoals == 0)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        static void PrintResults(char[,] matrix, int countCoals, int currentRow, int currentCol)
        {
            if (matrix[currentRow, currentCol] == 'e')
            {
                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");

                return;
            }
            if (countCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");

                return;
            }
            Console.WriteLine($"{countCoals} coals left. ({currentRow}, {currentCol})");
        }
    }
}
