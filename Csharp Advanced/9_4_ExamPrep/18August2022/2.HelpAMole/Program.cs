using System;

namespace _2.HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char MOLE_POS = 'M';
            const char TELEPORTER_POS = 'S'; //points -= 3 => S = EMPTY_POS
            const char EMPTY_POS = '-';
            const int POINTS_NEEDED = 25; //there will be cases, which mole starts with points, under 0
            const int TELEPORTER_PENALTY = 3;

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
                    if (line[col] == MOLE_POS)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            int collectedPoints = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                matrix[currentRow, currentCol] = EMPTY_POS;
                switch (command)
                {
                    case "up":
                        if (IsInMatrix(currentRow - 1, currentCol, matrix))
                        {
                            currentRow--;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "down":
                        if (IsInMatrix(currentRow + 1, currentCol, matrix))
                        {
                            currentRow++;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "left":
                        if (IsInMatrix(currentRow, currentCol - 1, matrix))
                        {
                            currentCol--;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "right":
                        if (IsInMatrix(currentRow, currentCol + 1, matrix))
                        {
                            currentCol++;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                }

                if (matrix[currentRow, currentCol] != TELEPORTER_POS && matrix[currentRow, currentCol] != EMPTY_POS && matrix[currentRow, currentCol] != MOLE_POS)
                {
                    char symbol = matrix[currentRow, currentCol];
                    int pointsPos = int.Parse(symbol.ToString());
                    collectedPoints += pointsPos;

                    matrix[currentRow, currentCol] = EMPTY_POS;
                }

                if (collectedPoints >= POINTS_NEEDED)
                {
                    break;
                }

                if (matrix[currentRow, currentCol] == TELEPORTER_POS)
                {
                    matrix[currentRow, currentCol] = EMPTY_POS;
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            if (matrix[i, j] == TELEPORTER_POS)
                            {
                                currentRow = i;
                                currentCol = j;
                            }
                        }
                    }
                    collectedPoints -= TELEPORTER_PENALTY;
                    matrix[currentRow, currentCol] = EMPTY_POS;
                }

            }
            matrix[currentRow, currentCol] = MOLE_POS;

            PrintResults(POINTS_NEEDED, matrixSize, matrix, collectedPoints);
        }

        static bool IsInMatrix(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static void PrintResults(int POINTS_NEEDED, int matrixSize, char[,] matrix, int collectedPoints)
        {
            if (collectedPoints >= POINTS_NEEDED)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {collectedPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {collectedPoints} points.");
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
