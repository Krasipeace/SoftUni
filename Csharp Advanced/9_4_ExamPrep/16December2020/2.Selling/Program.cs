using System;

namespace _2.Selling //80/100 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int currentRow = 0;
            int currentCol = 0;
            const char USER_POS = 'S';
            const char PILLAR_POS = 'O';
            const char EMPTY_POS = '-';

            for (int row = 0; row < matrixSize; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == USER_POS)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            const int MONEY_FOR_BAKERY = 50;
            int money = 0;

            while (money < MONEY_FOR_BAKERY)
            {
                string command = Console.ReadLine();

                matrix[currentRow, currentCol] = EMPTY_POS;

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

                if (currentRow < 0 || currentRow >= matrixSize || currentCol < 0 || currentRow >= matrixSize)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (matrix[currentRow, currentCol] != PILLAR_POS && matrix[currentRow, currentCol] != EMPTY_POS)
                {
                    char symbol = matrix[currentRow, currentCol];
                    int moneyOnPos = int.Parse(symbol.ToString());
                    money += moneyOnPos;
                }


                //searching for second pillar and teleporting to it.
                if (matrix[currentRow, currentCol] == PILLAR_POS)
                {
                    matrix[currentRow, currentCol] = EMPTY_POS;
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            if (matrix[i, j] == PILLAR_POS)
                            {
                                currentRow = i;
                                currentCol = j;
                            }
                        }
                    }
                    matrix[currentRow, currentCol] = EMPTY_POS;
                }

                if (currentRow == matrixSize - 1 && currentCol == matrixSize - 1)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                matrix[currentRow,currentCol] = USER_POS;
            }

            if (money >= MONEY_FOR_BAKERY)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

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
