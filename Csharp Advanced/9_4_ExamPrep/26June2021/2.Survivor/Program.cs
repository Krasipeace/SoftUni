using System;
using System.Linq;

namespace _2.Survivor //71/100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jagged = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
            }

            int foundTokens = 0;
            int enemyTokens = 0;
            int currentRow = 0;
            int currentCol = 0;
            const char TOKEN = 'T';
            const char EMPTY_POS = '-';
            const int OPPONENT_MOVES = 3;

            string commands = Console.ReadLine();
            while (commands != "Gong")
            {
                string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];
                currentRow = int.Parse(tokens[1]);
                currentCol = int.Parse(tokens[2]);

                switch (command)
                {
                    case "Find":
                        foundTokens = Find(jagged, foundTokens, currentRow, currentCol, TOKEN, EMPTY_POS);
                        break;
                    case "Opponent":
                        for (int i = 0; i < OPPONENT_MOVES; i++)
                        {
                            string enemyDirection = tokens[3];
                            enemyTokens = Opponent(jagged, enemyTokens, currentRow, currentCol, TOKEN, EMPTY_POS);
                            if (enemyDirection == "up")
                            {
                                currentRow--;
                                enemyTokens = Opponent(jagged, enemyTokens, currentRow, currentCol, TOKEN, EMPTY_POS);
                            }
                            else if (enemyDirection == "down")
                            {
                                currentRow++;
                                enemyTokens = Opponent(jagged, enemyTokens, currentRow, currentCol, TOKEN, EMPTY_POS);
                            }
                            else if (enemyDirection == "left")
                            {
                                currentCol--;
                                enemyTokens = Opponent(jagged, enemyTokens, currentRow, currentCol, TOKEN, EMPTY_POS);
                            }
                            else if (enemyDirection == "right")
                            {
                                currentCol++;
                                enemyTokens = Opponent(jagged, enemyTokens, currentRow, currentCol, TOKEN, EMPTY_POS);
                            }
                        }
                        break;
                }
                commands = Console.ReadLine();
            }
            PrintResults(jagged, foundTokens, enemyTokens);
        }

        static int Find(char[][] jagged, int foundTokens, int currentRow, int currentCol, char TOKEN, char EMPTY_POS)
        {
            if (isInField(jagged, currentRow, currentCol) && jagged[currentRow][currentCol] == TOKEN)
            {
                foundTokens++;
                jagged[currentRow][currentCol] = EMPTY_POS;

                return foundTokens;
            }
            else
            {
                return foundTokens--;
            }
        }
        static int Opponent(char[][] jagged, int enemyTokens, int currentRow, int currentCol, char TOKEN, char EMPTY_POS)
        {
            if (isInField(jagged, currentRow, currentCol) && jagged[currentRow][currentCol] == TOKEN)
            {
                enemyTokens++;
                jagged[currentRow][currentCol] = EMPTY_POS;

                return enemyTokens;
            }
            else
            {
                return enemyTokens--;
            }
        }

        static bool isInField(char[][] jagged, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < jagged.Length && currentCol >= 0 && currentCol < jagged[currentRow].Length;
        }

        static void PrintResults(char[][] jagged, int foundTokens, int enemyTokens)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }

            Console.WriteLine($"Collected tokens: {foundTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }
    }
}
