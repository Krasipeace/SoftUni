// F5 to reset, F6 to pause and play
using System;

namespace matrix
{
    class Program
    {
        private static Random random = new Random();
        private static char matrixSymbols
        {
            get
            {
                return GenerateSymbolsInCols();
            }
        }
        private static char GenerateSymbolsInCols()
        {
            int currentSymbol = random.Next(10);
            if (currentSymbol <= 2)
            {
                return (char)('0' + random.Next(10));
            }
            else if (currentSymbol <= 4)
            {
                return (char)('a' + random.Next(27));
            }
            else if (currentSymbol <= 6)
            {
                return (char)('A' + random.Next(27));
            }
            else
            {
                return (char)random.Next(32, 255);
            }
        }

        public static void Main()
        {
            ConsoleSettings();

            int width;
            int height;
            int[] y;

            ResetMatrixPlay(out width, out height, out y);

            while (true)
            {
                FallingSymbols(width, height, y);
            }
        }

        private static void ConsoleSettings()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.WriteLine("Hit Any Key To Continue");
            Console.ReadKey();
            Console.CursorVisible = false;
        }


        private static void ResetMatrixPlay(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;

            y = new int[width];

            Console.Clear();
            for (int x = 0; x < width; ++x)
            {
                y[x] = random.Next(height);
            }
        }


        private static void FallingSymbols(int width, int height, int[] y)
        {
            int x;
            for (x = 0; x < width; ++x)
            {
                LightFallingSymbols(y, x);

                DarkFallingSymbols(height, y, x);

                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(' ');

                y[x] = inScreenYPosition(y[x] + 1, height);
            }

            UserConstrols(ref width, ref height, ref y);
        }
        private static void LightFallingSymbols(int[] y, int x)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y[x]);
            Console.Write(matrixSymbols);
        }
        private static void DarkFallingSymbols(int height, int[] y, int x)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int temp = y[x] - 2;
            Console.SetCursorPosition(x, inScreenYPosition(temp, height));
            Console.Write(matrixSymbols);
        }
        private static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
            {
                return yPosition + height;
            }
            else if (yPosition < height)
            {
                return yPosition;
            }
            else
            {
                return 0;
            }
        }
        private static void UserConstrols(ref int width, ref int height, ref int[] y)
        {
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                {
                    ResetMatrixPlay(out width, out height, out y);
                }
                if (Console.ReadKey().Key == ConsoleKey.F6)
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }
    }
}
