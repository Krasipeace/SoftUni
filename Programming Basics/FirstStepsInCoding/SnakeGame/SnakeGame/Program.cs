using System;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var snakeLength = 5;
            var snake = new List<Point> { new Point(38, 15) };

            Console.CursorVisible = false;
            Console.SetCursorPosition(snake.Last().Item1, snake.Last().Item2);
            Console.Write("*");

            while (true)
            {
                var ch = Console.ReadKey(true).Key;
                if (ch == ConsoleKey.Q) break;

                var tail = snake.First();
                var head = snake.Last();

                if (snake.Count >= snakeLength)
                {
                    Console.SetCursorPosition(tail.X, tail.Y);
                    Console.Write(' ');
                    snake.RemoveAt(0);
                }

                switch (ch)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        snake.Add(new Point(head.X - 1, head.Y));
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        snake.Add(new Point(head.X, head.Y - 1));
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        snake.Add(new Point(head.X, head.Y + 1));
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        snake.Add(new Point(head.X + 1, head.Y));
                        break;
                }

                head = snake.Last();

                Console.SetCursorPosition(head.X, head.Y);
                Console.Write("*");
            }

            Console.CursorVisible = true;
        }
    }
}
