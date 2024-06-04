using System;
using System.Linq;

namespace _2.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char BLACK_TRUFFLE = 'B';
            const char SUMMER_TRUFFLE = 'S';
            const char WHITE_TRUFFLE = 'W';
            const char EMPTY_POS = '-';

            int wildBoarAte = 0;

            int countBlackTruffles = 0;
            int countSummerTruffles = 0;
            int countWhiteTruffles = 0;

            int forestSize = int.Parse(Console.ReadLine());
            char[,] forest = new char[forestSize, forestSize];
            for (int row = 0; row < forestSize; row++)
            {
                char[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < forestSize; col++)
                {
                    forest[row, col] = line[col];
                }
            }

            string commands = Console.ReadLine();
            while (commands != "Stop the hunt")
            {
                string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int currentRow = int.Parse(tokens[1]);
                int currentCol = int.Parse(tokens[2]);

                switch (command)
                {
                    case "Collect":
                        switch (forest[currentRow, currentCol])
                        {
                            case BLACK_TRUFFLE:
                                countBlackTruffles++;
                                break;
                            case SUMMER_TRUFFLE:
                                countSummerTruffles++;
                                break;
                            case WHITE_TRUFFLE:
                                countWhiteTruffles++;
                                break;
                        }
                        forest[currentRow, currentCol] = EMPTY_POS;
                        break;
                    case "Wild_Boar":
                        string direction = tokens[3];
                        if (direction == "up")
                        {
                            for (int rows = currentRow; rows >= 0; rows -= 2)
                            {
                                wildBoarAte = GetWildBoarUpDown(BLACK_TRUFFLE, SUMMER_TRUFFLE, WHITE_TRUFFLE, EMPTY_POS, wildBoarAte, forest, currentCol, rows);
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int rows = currentRow; rows < forestSize; rows += 2)
                            {
                                wildBoarAte = GetWildBoarUpDown(BLACK_TRUFFLE, SUMMER_TRUFFLE, WHITE_TRUFFLE, EMPTY_POS, wildBoarAte, forest, currentCol, rows);
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int cols = currentCol; cols >= 0; cols -= 2)
                            {
                                wildBoarAte = GetWildBoarLeftRight(BLACK_TRUFFLE, SUMMER_TRUFFLE, WHITE_TRUFFLE, EMPTY_POS, wildBoarAte, forest, currentRow, cols);
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int cols = currentCol; cols < forestSize; cols += 2)
                            {
                                wildBoarAte = GetWildBoarLeftRight(BLACK_TRUFFLE, SUMMER_TRUFFLE, WHITE_TRUFFLE, EMPTY_POS, wildBoarAte, forest, currentRow, cols);
                            }
                        }
                        break;
                }

                commands = Console.ReadLine();
            }
            PrintResults(wildBoarAte, countBlackTruffles, countSummerTruffles, countWhiteTruffles, forestSize, forest);
        }

        static int GetWildBoarUpDown(char BLACK_TRUFFLE, char SUMMER_TRUFFLE, char WHITE_TRUFFLE, char EMPTY_POS, int wildBoarAte, char[,] forest, int currentCol, int rows)
        {
            if (forest[rows, currentCol] == BLACK_TRUFFLE || forest[rows, currentCol] == SUMMER_TRUFFLE || forest[rows, currentCol] == WHITE_TRUFFLE)
            {
                forest[rows, currentCol] = EMPTY_POS;
                wildBoarAte++;
            }

            return wildBoarAte;
        }
        static int GetWildBoarLeftRight(char BLACK_TRUFFLE, char SUMMER_TRUFFLE, char WHITE_TRUFFLE, char EMPTY_POS, int wildBoarAte, char[,] forest, int currentRow, int cols)
        {
            if (forest[currentRow, cols] == BLACK_TRUFFLE || forest[currentRow, cols] == SUMMER_TRUFFLE || forest[currentRow, cols] == WHITE_TRUFFLE)
            {
                forest[currentRow, cols] = EMPTY_POS;
                wildBoarAte++;
            }

            return wildBoarAte;
        }

        static void PrintResults(int wildBoarAte, int countBlackTruffles, int countSummerTruffles, int countWhiteTruffles, int forestSize, char[,] forest)
        {
            Console.WriteLine($"Peter manages to harvest {countBlackTruffles} black, {countSummerTruffles} summer, and {countWhiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarAte} truffles.");

            for (int row = 0; row < forestSize; row++)
            {
                for (int col = 0; col < forestSize; col++)
                {
                    Console.Write($"{forest[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
