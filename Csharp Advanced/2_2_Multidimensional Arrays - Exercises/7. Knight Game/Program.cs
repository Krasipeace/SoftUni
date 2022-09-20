using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            if (matrixSize < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, matrixSize, matrix);

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }
                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        static int CountAttackedKnights(int row, int col, int matrixSize, char[,] matrix)
        {
            int attackedKnights = 0;

            if (isKnightMovingInTheMatrix(row - 1, col - 2, matrixSize))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row + 1, col - 2, matrixSize))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row - 1, col + 2, matrixSize))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row + 1, col + 2, matrixSize))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row - 2, col - 1, matrixSize))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row - 2, col + 1, matrixSize))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row + 2, col - 1, matrixSize))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isKnightMovingInTheMatrix(row + 2, col + 1, matrixSize))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        static bool isKnightMovingInTheMatrix(int row, int col, int matrixSize)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }
    }
}
