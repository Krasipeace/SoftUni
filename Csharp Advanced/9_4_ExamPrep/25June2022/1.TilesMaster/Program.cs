using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SINK = 40;
            const int OVEN = 50;
            const int COUNTERTOP = 60;
            const int WALL = 70;

            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ").Select(w => int.Parse(w)).ToArray());
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ").Select(g => int.Parse(g)).ToArray());

            Dictionary<string, int> formedTiles = new Dictionary<string, int>
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor", 0},
            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentWhite = whiteTiles.Pop();
                int currentGrey = greyTiles.Dequeue();
                int sum = currentWhite + currentGrey;

                if (currentWhite == currentGrey)
                {
                    switch (sum)
                    {
                        case SINK:
                            formedTiles["Sink"]++;
                            break;
                        case OVEN:
                            formedTiles["Oven"]++;
                            break;
                        case COUNTERTOP:
                            formedTiles["Countertop"]++;
                            break;
                        case WALL:
                            formedTiles["Wall"]++;
                            break;
                        default:
                            formedTiles["Floor"]++;
                            break;
                    }
                }
                else
                {
                    currentWhite /= 2;
                    whiteTiles.Push(currentWhite);
                    greyTiles.Enqueue(currentGrey);
                }
            }

            PrintResults(whiteTiles, greyTiles, formedTiles);
        }

        static void PrintResults(Stack<int> whiteTiles, Queue<int> greyTiles, Dictionary<string, int> formedTiles)
        {
            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var item in formedTiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
