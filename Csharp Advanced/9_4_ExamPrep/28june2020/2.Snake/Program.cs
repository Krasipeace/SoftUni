using System;

namespace _2.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int FOOD_NEEDED = 10;
            const char SNAKE_POS = 'S';
            const char SNAKE_TRAIL = '.';
            const char BURROW_POS = 'B';
            const char FOOD_POS = '*';

            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];
            int snakeRow = 0;
            int snakeCol = 0;
            int burrowOneRow = 0;
            int burrowOneCol = 0;
            int burrowTwoRow = 0;
            int burrowTwoCol = 0;
            int burrowCount = 0;

            GetField(SNAKE_POS, BURROW_POS, fieldSize, field, ref snakeRow, ref snakeCol, ref burrowOneRow, ref burrowOneCol, ref burrowTwoRow, ref burrowTwoCol, ref burrowCount);

            int foodCount = 0;

            while (foodCount != FOOD_NEEDED)
            {
                field[snakeRow, snakeCol] = SNAKE_TRAIL;

                string input = Console.ReadLine();
                snakeRow = MoveRow(snakeRow, input);
                snakeCol = MoveCol(snakeCol, input);

                if (IsInsideField(snakeRow, snakeCol, fieldSize, fieldSize) == true)
                {
                    SnakeMovement(SNAKE_POS, SNAKE_TRAIL, BURROW_POS, FOOD_POS, field, ref snakeRow, ref snakeCol, burrowOneRow, burrowOneCol, burrowTwoRow, burrowTwoCol, ref foodCount);
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }
            }

            PrintResults(FOOD_NEEDED, field, foodCount);
        }

        static void GetField(char SNAKE_POS, char BURROW_POS, int fieldSize, char[,] field, ref int snakeRow, ref int snakeCol, ref int burrowOneRow, ref int burrowOneCol, ref int burrowTwoRow, ref int burrowTwoCol, ref int burrowCount)
        {
            for (int row = 0; row < fieldSize; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = rowInput[col];

                    if (rowInput[col] == SNAKE_POS)
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (rowInput[col] == BURROW_POS && burrowCount == 0)
                    {
                        burrowOneRow = row;
                        burrowOneCol = col;
                        burrowCount++;
                    }

                    if (rowInput[col] == BURROW_POS && burrowCount != 0)
                    {
                        burrowTwoRow = row;
                        burrowTwoCol = col;
                    }
                }
            }
        }

        static int MoveRow(int snakeRow, string input)
        {
            switch (input)
            {
                case "up":
                    snakeRow = snakeRow - 1;
                    break;
                case "down":
                    snakeRow = snakeRow + 1;
                    break;
            }

            return snakeRow;
        }
        static int MoveCol(int snakeCol, string input)
        {
            switch (input)
            {
                case "left":
                    snakeCol = snakeCol - 1;
                    break;
                case "right":
                    snakeCol = snakeCol + 1;
                    break;
            }

            return snakeCol;
        }
        static bool IsInsideField(int snakeRow, int snakeCol, int totalRow, int totalCol)
        {
            return (snakeRow >= 0 && snakeRow < totalRow && snakeCol >= 0 && snakeCol < totalCol);
        }

        static void SnakeMovement(char SNAKE_POS, char SNAKE_TRAIL, char BURROW_POS, char FOOD_POS, char[,] field, ref int snakeRow, ref int snakeCol, int burrowOneRow, int burrowOneCol, int burrowTwoRow, int burrowTwoCol, ref int foodCount)
        {
            if (field[snakeRow, snakeCol] == FOOD_POS)
            {
                foodCount++;
            }
            else if (field[snakeRow, snakeCol] == BURROW_POS)
            {
                field[snakeRow, snakeCol] = SNAKE_TRAIL;

                if (snakeRow == burrowOneRow && snakeCol == burrowOneCol)
                {
                    snakeRow = burrowTwoRow;
                    snakeCol = burrowTwoCol;
                }
                else
                {
                    snakeRow = burrowOneRow;
                    snakeCol = burrowOneCol;
                }
            }
            field[snakeRow, snakeCol] = SNAKE_POS;
        }

        static void PrintResults(int FOOD_NEEDED, char[,] field, int foodCount)
        {
            if (foodCount == FOOD_NEEDED)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodCount}");
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
