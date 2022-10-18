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
            //PLAYER movements
            bool isFinished = false;
            for (int i = 0; i < countOfCommands; i++)
            {
                if (matrix[currentRow, currentCol] == PLAYER)
                {
                    matrix[currentRow, currentCol] = EMPTY_POS;
                }

                string direction = Console.ReadLine();
                GetPos(matrixSize, matrix, ref currentRow, ref currentCol, direction);

                if (matrix[currentRow, currentCol] == BONUS_POS)
                {
                    GetPos(matrixSize, matrix, ref currentRow, ref currentCol, direction);
                }
                if (matrix[currentRow, currentCol] == TRAP_POS)
                {
                    GetTrap(matrixSize, matrix, ref currentRow, ref currentCol, direction);
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

        static void GetPos(int matrixSize, char[,] matrix, ref int currentRow, ref int currentCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    currentRow--;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentRow < 0)
                    {
                        currentRow = matrixSize - 1;
                    }
                    break;
                case "down":
                    currentRow++;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentRow > matrixSize - 1)
                    {
                        currentRow = 0;
                    }
                    break;
                case "left":
                    currentCol--;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentRow < 0)
                    {
                        currentCol = matrixSize - 1;
                    }
                    break;
                case "right":
                    currentCol++;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentCol > matrixSize - 1)
                    {
                        currentCol = 0;
                    }
                    break;
            }
        }
        static void GetTrap(int matrixSize, char[,] matrix, ref int currentRow, ref int currentCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    currentRow++;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentRow > matrixSize - 1)
                    {
                        currentRow = 0;
                    }
                    break;
                case "down":
                    currentRow--;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentRow < 0)
                    {
                        currentRow = matrixSize - 1;
                    }
                    break;
                case "left":
                    currentCol++;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentRow > matrixSize - 1)
                    {
                        currentCol = 0;
                    }
                    break;
                case "right":
                    currentCol--;
                    (currentRow, currentCol) = IsOutside(matrix, currentRow, currentCol);
                    if (currentCol < 0)
                    {
                        currentCol = matrixSize - 1;
                    }
                    break;
            }
        }

        public static (int row, int col) IsOutside(char[,] matrix, int currentRow, int currentCol)
        {
            if (currentRow < 0)
            {
                currentRow = matrix.GetLength(0) - 1;
            }
            else if (currentRow >= matrix.GetLength(0))
            {
                currentRow = 0;
            }

            if (currentCol < 0)
            {
                currentCol = matrix.GetLength(1) - 1;
            }
            else if (currentCol >= matrix.GetLength(1))
            {
                currentCol = 0;
            }

            return (currentRow, currentCol);
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
