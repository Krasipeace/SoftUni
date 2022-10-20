using System;

namespace _2.Armory //83/100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char ARMY_OFFICER_POS = 'A';
            const char MIRROR_POS = 'M';
            const char EMPTY_POS = '-';
            const int KING_GOLD = 65;

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
                    if (line[col] == ARMY_OFFICER_POS)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            int paidGold = 0;
            while (paidGold < KING_GOLD)
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
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                if (matrix[currentRow, currentCol] != MIRROR_POS && matrix[currentRow, currentCol] != EMPTY_POS)
                {
                    char symbol = matrix[currentRow, currentCol];
                    int goldForSword = int.Parse(symbol.ToString());
                    paidGold += goldForSword;                   
                }

                if (matrix[currentRow, currentCol] == MIRROR_POS)
                {
                    matrix[currentRow, currentCol] = EMPTY_POS;
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            if (matrix[i, j] == MIRROR_POS)
                            {
                                currentRow = i;
                                currentCol = j;
                            }
                        }
                    }
                    matrix[currentRow, currentCol] = EMPTY_POS;
                }

                if ((currentRow == matrixSize - 1 && currentCol == matrixSize - 1) || (currentRow == matrixSize + 1 && currentCol == matrixSize + 1))
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                matrix[currentRow, currentCol] = ARMY_OFFICER_POS;
            }

            if (paidGold >= KING_GOLD)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {paidGold} gold coins.");

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