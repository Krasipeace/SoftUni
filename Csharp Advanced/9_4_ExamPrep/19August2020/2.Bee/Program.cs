using System;

namespace _2.Bee //77/100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char EMPTY_POS = '.';
            const char FLOWER_POS = 'f';
            const char BONUS_POS = 'O';
            const char BEE_POS = 'B';
            char[,] matrix;
            int beeRow, beeCol;

            GetField(BEE_POS, out matrix, out beeRow, out beeCol);

            int polinatedFlowers = 0;
            bool isLost = false;

            string direction = Console.ReadLine();
            while (direction != "End")
            {
                matrix[beeRow, beeCol] = EMPTY_POS;

                BeeDirection(ref beeRow, ref beeCol, direction);

                if (!IsValidPosition(matrix, beeRow, beeCol))
                {
                    isLost = true;
                    break;
                }

                if (matrix[beeRow, beeCol].Equals(BONUS_POS))
                {
                    matrix[beeRow, beeCol] = EMPTY_POS;

                    BeeDirection(ref beeRow, ref beeCol, direction);

                    if (!IsValidPosition(matrix, beeRow, beeCol))
                    {
                        isLost = true;
                        break;
                    }
                }

                if (matrix[beeRow, beeCol].Equals(FLOWER_POS))
                {
                    polinatedFlowers++;
                    matrix[beeRow, beeCol] = EMPTY_POS;
                }
                direction = Console.ReadLine();
            }
            matrix[beeRow, beeCol] = BEE_POS;

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            const int FLOWER_POLINATION = 5;
            if (polinatedFlowers >= FLOWER_POLINATION)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {Math.Abs(FLOWER_POLINATION - polinatedFlowers)} flowers more");
            }
            PrintMatrix(matrix);
        }

        static void GetField(char BEE_POS, out char[,] matrix, out int beeRow, out int beeCol)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            matrix = new char[matrixSize, matrixSize];
            beeRow = -1;
            beeCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];

                    if (matrix[row, col].Equals(BEE_POS))
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
        }

        static void BeeDirection(ref int beeRow, ref int beeCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "left":
                    beeCol--;
                    break;
                case "right":
                    beeCol++;
                    break;
            }
        }

        static bool IsValidPosition(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
