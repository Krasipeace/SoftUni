using System;
using System.Linq;

namespace _2.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char PLAYER = 'f';
            const char FINNISH_POS = 'F';
            const char BONUS_POS = 'B';
            const char TRAP_POS = 'T';
            const char EMPTY_POS = '-';

            int matrixSize = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            int currentRow = 0;
            int currentCol = 0;

            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == PLAYER)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            bool isFinished = false;
            for (int i = 0; i < countOfCommands; i++)
            {
                if (matrix[currentRow, currentCol] == PLAYER)
                {
                    matrix[currentRow, currentCol] = EMPTY_POS;
                }
                //PLAYER movements

                string direction = Console.ReadLine();
                GetPos(matrixSize, ref currentRow, ref currentCol, direction);

                if (matrix[currentRow, currentCol] == BONUS_POS)
                {
                    GetPos(matrixSize, ref currentRow, ref currentCol, direction);
                }
                if (matrix[currentRow, currentCol] == TRAP_POS)
                {
                    GetTrap(matrixSize, ref currentRow, ref currentCol, direction);
                }

                if (matrix[currentRow, currentCol] == FINNISH_POS)
                {
                    isFinished = true;
                    matrix[currentRow, currentCol] = PLAYER;

                    break;
                }

            }

            PrintResults(matrixSize, matrix, isFinished, currentRow, currentCol, PLAYER);

        }

        static void GetPos(int matrixSize, ref int currentRow, ref int currentCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow = matrixSize - 1;
                    }
                    break;
                case "down":
                    currentRow++;
                    if (currentRow > matrixSize - 1)
                    {
                        currentRow = 0;
                    }
                    break;
                case "left":
                    currentCol--;
                    if (currentRow < 0)
                    {
                        currentCol = matrixSize - 1;
                    }
                    break;
                case "right":
                    currentCol++;
                    if (currentCol > matrixSize - 1)
                    {
                        currentCol = 0;
                    }
                    break;
            }
        }
        static void GetTrap(int matrixSize, ref int currentRow, ref int currentCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    currentRow++;
                    if (currentRow > matrixSize - 1)
                    {
                        currentRow = 0;
                    }
                    break;
                case "down":
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow = matrixSize - 1;
                    }
                    break;
                case "left":
                    currentCol++;
                    if (currentRow > matrixSize - 1)
                    {
                        currentCol = 0;
                    }
                    break;
                case "right":
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol = matrixSize - 1;
                    }
                    break;
            }
        }
        static void PrintResults(int matrixSize, char[,] matrix, bool isFinished, int currentRow, int currentCol, char PLAYER)
        {
            if (isFinished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
                matrix[currentRow, currentCol] = PLAYER;
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
