using System;
using System.Linq;

namespace _2.Warships //70/100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char FIELD_POS = '*';           //miss hit
            const char FIRST_PLAYER_SHIP = '<';
            const char SECOND_PLAYER_SHIP = '>';
            const char SEA_MINE = '#';            //bomb explosion
            const char DESTROYED_OBJECT = 'X';

            int fieldSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSize, fieldSize];

            int firstPlayerAliveShips = 0;   //counts starting  ships
            int secondPlayerAliveShips = 0;  //------ ----- -----

            string[] playersCommands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);


            //--> initializing battlefield
            for (int row = 0; row < fieldSize; row++)
            {
                char[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = line[col];

                    if (field[row, col] == FIRST_PLAYER_SHIP)
                    {
                        firstPlayerAliveShips++;
                    }
                    if (field[row, col] == SECOND_PLAYER_SHIP)
                    {
                        secondPlayerAliveShips++;
                    }
                }
            }

            int firstPlayerDestroyedShips = 0;   //counts destroyed ships
            int secondPlayerDestroyedShips = 0;  // -- -- --

            //--> players in battle
            for (int i = 0; i < playersCommands.Length; i++)
            {
                string[] playerAttemptsToHit = playersCommands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int currentRow = int.Parse(playerAttemptsToHit[0]);
                int currentCol = int.Parse(playerAttemptsToHit[1]);

                //--> check if hit is in the battlefield
                if (!isHitInField(field, currentRow, currentCol))
                {
                    continue;
                }

                //--> direct hits 

                if (field[currentRow, currentCol] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow, currentCol] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow, currentCol] = DESTROYED_OBJECT;

                //--> check if any player hit SEA_MINE and destroy any ship in the area of the bomb explosion

                if (field[currentRow, currentCol] == SEA_MINE)
                {
                    field[currentRow, currentCol] = DESTROYED_OBJECT;

                    SeaMineExplosion(FIRST_PLAYER_SHIP, SECOND_PLAYER_SHIP, DESTROYED_OBJECT, field, ref firstPlayerDestroyedShips, ref secondPlayerDestroyedShips, currentRow, currentCol);

                    continue;
                }               

                //--> check if any player has no ships left
                int totalDestroyedShips = firstPlayerDestroyedShips + secondPlayerDestroyedShips;
                if (firstPlayerDestroyedShips == firstPlayerAliveShips)
                {
                    Console.WriteLine($"Player Two has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
                    break;
                }
                if (secondPlayerDestroyedShips == secondPlayerAliveShips)
                {
                    Console.WriteLine($"Player One has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
                    break;
                }
            }

            //--> draw 
            int playerOneLeftShipsAlive = firstPlayerAliveShips - firstPlayerDestroyedShips;
            int playerTwoLeftShipsAlive = secondPlayerAliveShips - secondPlayerDestroyedShips;

            if (playerOneLeftShipsAlive != 0 && playerTwoLeftShipsAlive != 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneLeftShipsAlive} ships left. Player Two has {playerTwoLeftShipsAlive} ships left.");
            }
        }

        static void SeaMineExplosion(char FIRST_PLAYER_SHIP, char SECOND_PLAYER_SHIP, char DESTROYED_OBJECT, char[,] field, ref int firstPlayerDestroyedShips, ref int secondPlayerDestroyedShips, int currentRow, int currentCol)
        {
            if (isHitInField(field, currentRow - 1, currentCol))
            {
                if (field[currentRow - 1, currentCol] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow - 1, currentCol] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow - 1, currentCol] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow + 1, currentCol))
            {
                if (field[currentRow + 1, currentCol] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow + 1, currentCol] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow + 1, currentCol] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow, currentCol - 1))
            {
                if (field[currentRow, currentCol - 1] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow, currentCol - 1] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow, currentCol - 1] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow, currentCol + 1))
            {
                if (field[currentRow, currentCol + 1] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow, currentCol + 1] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow, currentCol + 1] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow - 1, currentCol + 1))
            {
                if (field[currentRow - 1, currentCol + 1] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow - 1, currentCol + 1] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow - 1, currentCol + 1] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow - 1, currentCol - 1))
            {
                if (field[currentRow - 1, currentCol - 1] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow - 1, currentCol - 1] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow - 1, currentCol - 1] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow + 1, currentCol - 1))
            {
                if (field[currentRow + 1, currentCol - 1] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow + 1, currentCol - 1] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow + 1, currentCol - 1] = DESTROYED_OBJECT;
            }
            if (isHitInField(field, currentRow + 1, currentCol + 1))
            {
                if (field[currentRow + 1, currentCol + 1] == FIRST_PLAYER_SHIP)
                {
                    firstPlayerDestroyedShips++;
                }
                if (field[currentRow + 1, currentCol + 1] == SECOND_PLAYER_SHIP)
                {
                    secondPlayerDestroyedShips++;
                }
                field[currentRow + 1, currentCol + 1] = DESTROYED_OBJECT;
            }
        }

        static bool isHitInField(char[,] field, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < field.GetLength(0) && currentCol >= 0 && currentCol < field.GetLength(1);
        }
    }
}
