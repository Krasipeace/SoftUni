using System;

namespace _2.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char MARIO = 'M';
            const string BOWSER = "B";
            const string PRINCESS = "P";
            const string EMPTY_POS = "-";
            const string DEAD_MARIO = "X";
            //const int MOVEMENT_PENALTY = 1;
            const int BOWSER_BATTLE = 2;

            int marioHitPoints = int.Parse(Console.ReadLine());
            int mazeRows = int.Parse(Console.ReadLine());

            string[][] maze = new string[mazeRows][];
            int currentMarioRow = 0;
            int currentMarioCol = 0;

            for (int row = 0; row < maze.Length; row++)
            {
                string line = Console.ReadLine();
                maze[row] = new string[line.Length];
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (line[col] == MARIO)
                    {
                        currentMarioRow = row;
                        currentMarioCol = col;
                    }
                    maze[row][col] = line[col].ToString();
                }
            }

            bool isPrincessSave = false;
            bool isMarioDead = false;
            while (!isPrincessSave && !isMarioDead)
            {
                string[] playerCommands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = playerCommands[0];

                int bowserSpawnRow = int.Parse(playerCommands[1]);
                int bowserSpawnCol = int.Parse(playerCommands[2]);
                maze[bowserSpawnRow][bowserSpawnCol] = BOWSER;

                marioHitPoints--; //MOVEMENT_PENALTY
                switch (direction)
                {
                    case "W": //up
                        if (IsMoveInMaze(maze, currentMarioRow - 1, currentMarioCol))
                        {
                            currentMarioRow--;
                            maze[currentMarioRow + 1][currentMarioCol] = EMPTY_POS;

                            GetNewPos(MARIO, BOWSER, PRINCESS, EMPTY_POS, BOWSER_BATTLE, ref marioHitPoints, maze, currentMarioRow, currentMarioCol, ref isPrincessSave);
                        }
                        break;
                    case "S": //down
                        if (IsMoveInMaze(maze, currentMarioRow + 1, currentMarioCol))
                        {
                            currentMarioRow++;
                            maze[currentMarioRow - 1][currentMarioCol] = EMPTY_POS;

                            GetNewPos(MARIO, BOWSER, PRINCESS, EMPTY_POS, BOWSER_BATTLE, ref marioHitPoints, maze, currentMarioRow, currentMarioCol, ref isPrincessSave);
                        }
                        break;
                    case "A": //left
                        if (IsMoveInMaze(maze, currentMarioRow, currentMarioCol - 1))
                        {
                            currentMarioCol--;
                            maze[currentMarioRow][currentMarioCol + 1] = EMPTY_POS;

                            GetNewPos(MARIO, BOWSER, PRINCESS, EMPTY_POS, BOWSER_BATTLE, ref marioHitPoints, maze, currentMarioRow, currentMarioCol, ref isPrincessSave);
                        }
                        break;

                    case "D": //right
                        if (IsMoveInMaze(maze, currentMarioRow, currentMarioCol + 1))
                        {
                            currentMarioCol++;
                            maze[currentMarioRow][currentMarioCol - 1] = EMPTY_POS;

                            GetNewPos(MARIO, BOWSER, PRINCESS, EMPTY_POS, BOWSER_BATTLE, ref marioHitPoints, maze, currentMarioRow, currentMarioCol, ref isPrincessSave);
                        }
                        break;
                }

                if (marioHitPoints <= 0)
                {
                    isMarioDead = true;
                    maze[currentMarioRow][currentMarioCol] = DEAD_MARIO;
                }
            }
            PrintResults(marioHitPoints, maze, currentMarioRow, currentMarioCol, isPrincessSave, isMarioDead);
        }

        static bool IsMoveInMaze(string[][] maze, int currentMarioRow, int currentMarioCol)
        {
            return currentMarioRow >= 0 && currentMarioRow < maze.Length && currentMarioCol >= 0 && currentMarioCol < maze[currentMarioRow].Length;
        }

        static void GetNewPos(char MARIO, string BOWSER, string PRINCESS, string EMPTY_POS, int BOWSER_BATTLE, ref int marioHitPoints, string[][] maze, int currentMarioRow, int currentMarioCol, ref bool isPrincessSave)
        {
            if (maze[currentMarioRow][currentMarioCol] == BOWSER)
            {
                marioHitPoints -= BOWSER_BATTLE;
                maze[currentMarioRow][currentMarioCol] = MARIO.ToString();
            }
            else if (maze[currentMarioRow][currentMarioCol] == PRINCESS)
            {
                maze[currentMarioRow][currentMarioCol] = EMPTY_POS;
                isPrincessSave = true;
            }
            else //EMPTY_POS
            {
                maze[currentMarioRow][currentMarioCol] = MARIO.ToString();
            }
        }

        static void PrintResults(int marioHitPoints, string[][] maze, int currentMarioRow, int currentMarioCol, bool isPrincessSave, bool isMarioDead)
        {
            if (isMarioDead)
            {
                Console.WriteLine($"Mario died at {currentMarioRow};{currentMarioCol}.");
            }
            if (isPrincessSave)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioHitPoints}");
            }

            foreach (var item in maze)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
    }
}
