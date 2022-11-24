using System;
using System.Drawing;
using System.Threading;

namespace logo_train
{
    internal class Train
    {
        static void Main(string[] args)
        {

            char[] name = new char[] { 'K', 'R', 'A', 'S', 'I', 'P', 'E', 'A', 'C', 'E', 'o', 'o', 'o', 'o', 'o' };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("     . . . . o o o o");
                    for (int s = 0; s < j / 2; s++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {name[s]}");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    string margin = "".PadLeft(j);
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.WriteLine(margin + "                _____      .");
                    Console.ForegroundColor= ConsoleColor.DarkBlue;
                    Console.WriteLine(margin + "       ____====  ]OO|_n_n__][.");
                    Console.WriteLine(margin + "      [________]_|__|________)< ");
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.WriteLine(margin + "       oo    oo  'oo OOOO-| oo\\_");
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.WriteLine("   +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+");

                    Thread.Sleep(200);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
