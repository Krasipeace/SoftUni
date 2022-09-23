using System;
using System.Linq;

namespace _10._RMV_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fieldSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int fieldRows = int.Parse(fieldSize[0]);
            int fieldCols = int.Parse(fieldSize[1]);

            var matrix = new char[fieldRows, fieldCols];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < fieldRows; row++)
            {
                string inputCell = Console.ReadLine();

                for (int col = 0; col < fieldCols; col++)
                {
                    matrix[row, col] = inputCell[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string playerMoveCommand = Console.ReadLine();
            PlayerMovement(ref matrix, ref playerRow, ref playerCol, playerMoveCommand);
        }

        static void PlayerMovement(ref char[,] matrix, ref int playerRow, ref int playerCol, string playerMoveCommand)
        {
            for (int currentMove = 0; currentMove < playerMoveCommand.Length; currentMove++)
            {
                char direction = playerMoveCommand[currentMove];
                switch (direction)
                {
                    case 'U':
                        MoveUp(matrix, playerRow, playerCol);
                        playerRow--;
                        if (BunniesSpreadInCells(ref matrix, playerRow, playerCol))
                        {
                            GameOver(matrix, playerRow, playerCol);
                        }
                        break;
                    case 'D':
                        MoveDown(matrix, playerRow, playerCol);
                        playerRow++;
                        if (BunniesSpreadInCells(ref matrix, playerRow, playerCol))
                        {
                            GameOver(matrix, playerRow, playerCol);
                        }
                        break;
                    case 'L':
                        MoveLeft(matrix, playerRow, playerCol);
                        playerCol--;
                        if (BunniesSpreadInCells(ref matrix, playerRow, playerCol))
                        {
                            GameOver(matrix, playerRow, playerCol);
                        }
                        break;
                    case 'R':
                        MoveRight(matrix, playerRow, playerCol);
                        playerCol++;
                        if (BunniesSpreadInCells(ref matrix, playerRow, playerCol))
                        {
                            GameOver(matrix, playerRow, playerCol);
                        }
                        break;
                }
            }
        }

        static void MoveUp(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentRow == 0)
            {
                BunniesSpreadInCells(ref matrix, currentRow, currentCol);

                GameWon(matrix, currentRow, currentCol);
            }
            else
            {
                if (matrix[currentRow - 1, currentCol] == 'B')
                {
                    BunniesSpreadInCells(ref matrix, currentRow, currentCol);

                    GameOver(matrix, currentRow - 1, currentCol);
                }
                else
                {
                    matrix[currentRow - 1, currentCol] = 'P';
                }
            }
        }
        static void MoveDown(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentRow == matrix.GetLength(0) - 1)
            {
                BunniesSpreadInCells(ref matrix, currentRow, currentCol);

                GameWon(matrix, currentRow, currentCol);
            }
            else
            {
                if (matrix[currentRow + 1, currentCol] == 'B')
                {
                    BunniesSpreadInCells(ref matrix, currentRow, currentCol);

                    GameOver(matrix, currentRow + 1, currentCol);
                }
                else
                {
                    matrix[currentRow + 1, currentCol] = 'P';
                }
            }
        }

        static void MoveRight(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentCol == matrix.GetLength(1) - 1)
            {
                BunniesSpreadInCells(ref matrix, currentRow, currentCol);
                GameWon(matrix, currentRow, currentCol);
            }
            else
            {
                if (matrix[currentRow, currentCol + 1] == 'B')
                {
                    BunniesSpreadInCells(ref matrix, currentRow, currentCol);
                    GameOver(matrix, currentRow, currentCol + 1);
                }
                else
                {
                    matrix[currentRow, currentCol + 1] = 'P';
                }
            }
        }

        static void MoveLeft(char[,] matrix, int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = '.';

            if (currentCol == 0)
            {
                BunniesSpreadInCells(ref matrix, currentRow, currentCol);

                GameWon(matrix, currentRow, currentCol);
            }
            else
            {
                if (matrix[currentRow, currentCol - 1] == 'B')
                {
                    BunniesSpreadInCells(ref matrix, currentRow, currentCol);

                    GameOver(matrix, currentRow, currentCol - 1);
                }
                else
                {
                    matrix[currentRow, currentCol - 1] = 'P';
                }
            }
        }

        static bool BunniesSpreadInCells(ref char[,] matrix, int currentRow, int currentCol)
        {
            char[,] result = new char[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, result, matrix.Length);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i > 0 && matrix[i, j] == 'B')
                    {
                        result[i - 1, j] = 'B';
                    }

                    if (i < matrix.GetLength(0) - 1 && matrix[i, j] == 'B')
                    {
                        result[i + 1, j] = 'B';
                    }

                    if (j > 0 && matrix[i, j] == 'B')
                    {
                        result[i, j - 1] = 'B';
                    }

                    if (j < matrix.GetLength(1) - 1 && matrix[i, j] == 'B')
                    {
                        result[i, j + 1] = 'B';
                    }
                }
            }

            bool isDead = true;

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] == 'P')
                    {
                        isDead = false;
                    }
                }
            }
            matrix = result;

            return isDead;
        }

        static void GameOver(char[,] matrix, int currentRow, int currentCol)
        {
            PrintResult(matrix);
            Console.WriteLine($"dead: {currentRow} {currentCol}");
            Environment.Exit(0);
        }

        static void GameWon(char[,] matrix, int currentRow, int currentCol)
        {
            PrintResult(matrix);
            Console.WriteLine($"won: {currentRow} {currentCol}");
            Environment.Exit(0);
        }

        static void PrintResult(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
