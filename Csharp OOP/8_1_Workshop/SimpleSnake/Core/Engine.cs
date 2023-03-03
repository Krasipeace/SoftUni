using System;
using System.Diagnostics;
using System.Threading;

using SimpleSnake.Core.Contracts;
using SimpleSnake.GameObjects;
using SimpleSnake.Utilities;
using SimpleSnake.Enums;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private readonly Stopwatch timer;
        private readonly Point[] directionPoints;
        private Direction direction;
        private Snake snake;
        private readonly Wall wall;
        private double sleepTime;
        private double difficultyStep;

        private Engine()
        {
            directionPoints = new Point[4];
            sleepTime = Constants.DEFAULT_SLEEP_TIME;
            timer = new Stopwatch();
        }

        public Engine(Wall wall) : this()
        {
            this.wall = wall;
        }

        public void Run()
        {
            this.GetDirectionPoints();
            this.SetDifficultyLevel();

            while (true)
            {
                this.timer.Start();
                this.ShowScore();

                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool canMove = snake.CanMove(this.directionPoints[(int)this.direction]);

                if (!canMove)
                {
                    this.InitializeRestart();
                }

                this.sleepTime -= difficultyStep;
                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void SetDifficultyLevel()
        {
            Console.SetCursorPosition(this.wall.LeftX + 1, 3);
            Console.Write("Choose Difficulty: ");
            Console.SetCursorPosition(this.wall.LeftX + 1, 4);
            Console.Write("1: Easy");
            Console.SetCursorPosition(this.wall.LeftX + 1, 5);
            Console.Write("2: Medium");
            Console.SetCursorPosition(this.wall.LeftX + 1, 6);
            Console.Write("3: Hard");
            Console.SetCursorPosition(this.wall.LeftX + 1, 7);

            string chosenDifficulty = Console.ReadLine();

            switch (chosenDifficulty)
            {
                case "1":
                    difficultyStep = Constants.DIFFICULTY_STEP_EASY;
                    break;
                case "2":
                    difficultyStep = Constants.DIFFICULTY_STEP_MEDIUM;
                    break;
                case "3":
                    difficultyStep = Constants.DIFFICULTY_STEP_HARD;
                    break;
                default:
                    StartUp.Main();
                    break;
            }

            Console.Clear();
            this.wall.InitializeGameField();
            this.snake = new Snake(this.wall);
        }

        private void GetDirectionPoints()
        {
            this.directionPoints[(int)Direction.Right] = new GameObjects.Point(1, 0);
            this.directionPoints[(int)Direction.Left] = new GameObjects.Point(-1, 0);
            this.directionPoints[(int)Direction.Up] = new GameObjects.Point(0, -1);
            this.directionPoints[(int)Direction.Down] = new GameObjects.Point(0, 1);
        }

        private void ShowScore()
        {
            Console.SetCursorPosition(this.wall.LeftX + 1, 0);
            Console.Write($"Score: {this.snake.FoodEaten}");
            Console.SetCursorPosition(this.wall.LeftX + 1, 1);
            Console.Write($"Game duration: {this.timer.ElapsedMilliseconds / 1000000:d2}:{this.timer.ElapsedMilliseconds / 1000:d2}");
            Console.CursorVisible = false;
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow || userInput.Key == ConsoleKey.A)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow || userInput.Key == ConsoleKey.D)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow || userInput.Key == ConsoleKey.W)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow || userInput.Key == ConsoleKey.S)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void InitializeRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? Y/N");
            Console.SetCursorPosition(leftX, topY + 1);

            string chosenOption = Console.ReadLine();

            switch (chosenOption.ToLower())
            {
                case "y":
                    Console.Clear();
                    StartUp.Main();
                    break;
                default:
                    StopGame();
                    break;
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(this.wall.LeftX / 3, this.wall.TopY / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Game Over!");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }
    }
}
