using System;
using System.Linq;

namespace _2.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char FIVE_ARMIES_POS = 'A';
            const string ORCS_POS = "O";
            const string MORDOR_POS = "M";
            const string EMPTY_POS = "-";
            const string FIVE_ARMIES_DEAD = "X";
            const int BATTLE_PENALTY = 2;

            int armyArmor = int.Parse(Console.ReadLine());

            int currentRow = 0;
            int currentCol = 0;

            int rows = int.Parse(Console.ReadLine());
            string[][] field = new string[rows][];
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                field[row] = new string[line.Length];
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (line[col] == FIVE_ARMIES_POS)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    field[row][col] = line[col].ToString();
                }
            }

            bool isArmyReachedMordor = false;
            bool isArmyDead = false;

            while (!isArmyDead && !isArmyReachedMordor)
            {
                string[] commandsLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string armyDirection = commandsLine[0];
                int orcsRow = int.Parse(commandsLine[1]);
                int orcsCol = int.Parse(commandsLine[2]);

                field[orcsRow][orcsCol] = ORCS_POS;
                armyArmor--; //movement penalty

                switch (armyDirection)
                {
                    case "up":
                        if (isMoveInField(field, currentRow - 1, currentCol))
                        {
                            currentRow--;
                            field[currentRow + 1][currentCol] = EMPTY_POS;
                            GetDirections(FIVE_ARMIES_POS, ORCS_POS, MORDOR_POS, EMPTY_POS, BATTLE_PENALTY, ref armyArmor, currentRow, currentCol, field, ref isArmyReachedMordor);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "down":
                        if (isMoveInField(field, currentRow + 1, currentCol))
                        {
                            currentRow++;
                            field[currentRow - 1][currentCol] = EMPTY_POS;
                            GetDirections(FIVE_ARMIES_POS, ORCS_POS, MORDOR_POS, EMPTY_POS, BATTLE_PENALTY, ref armyArmor, currentRow, currentCol, field, ref isArmyReachedMordor);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "left":
                        if (isMoveInField(field, currentRow, currentCol - 1))
                        {
                            currentCol--;
                            field[currentRow][currentCol + 1] = EMPTY_POS;
                            GetDirections(FIVE_ARMIES_POS, ORCS_POS, MORDOR_POS, EMPTY_POS, BATTLE_PENALTY, ref armyArmor, currentRow, currentCol, field, ref isArmyReachedMordor);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "right":
                        if (isMoveInField(field, currentRow, currentCol + 1))
                        {
                            currentCol++;
                            field[currentRow][currentCol - 1] = EMPTY_POS;
                            GetDirections(FIVE_ARMIES_POS, ORCS_POS, MORDOR_POS, EMPTY_POS, BATTLE_PENALTY, ref armyArmor, currentRow, currentCol, field, ref isArmyReachedMordor);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }

                if (armyArmor <= 0)
                {
                    isArmyDead = true;
                    field[currentRow][currentCol] = FIVE_ARMIES_DEAD;
                }
            }



            if (isArmyDead)
            {
                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
            }
            if (isArmyReachedMordor)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            foreach (var item in field)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        static bool isMoveInField(string[][] field, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < field.Length && currentCol >= 0 && currentCol < field[currentRow].Length;
        }

        static void GetDirections(char FIVE_ARMIES_POS, string ORCS_POS, string MORDOR_POS, string EMPTY_POS, int BATTLE_PENALTY, ref int armyArmor, int currentRow, int currentCol, string[][] field, ref bool isArmyReachedMordor)
        {
            if (field[currentRow][currentCol] == ORCS_POS)
            {
                armyArmor -= BATTLE_PENALTY;
                field[currentRow][currentCol] = FIVE_ARMIES_POS.ToString();
            }
            else if (field[currentRow][currentCol] == MORDOR_POS)
            {
                field[currentRow][currentCol] = EMPTY_POS;
                isArmyReachedMordor = true;
            }
            else //EMPTY_POS
            {
                field[currentRow][currentCol] = FIVE_ARMIES_POS.ToString();
            }
        }
    }
}
