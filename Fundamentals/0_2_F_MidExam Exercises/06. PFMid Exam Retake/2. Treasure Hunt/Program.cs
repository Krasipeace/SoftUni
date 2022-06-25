using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Treasure_Hunt  //The pirates need to carry a treasure chest safely back to the ship, looting along the way.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Yohoho!")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Loot")
                {
                    for (int i = 1; i < tokens.Length; i++)   //removing "Loot"
                    {
                        if (!chest.Contains(tokens[i]))
                        {
                            chest.Insert(0, tokens[i]);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int item = int.Parse(tokens[1]);

                    if (item >= 0 && item < chest.Count)
                    {
                        string removedItem = chest[item];

                        chest.RemoveAt(item);
                        chest.Add(removedItem);
                    }
                }
                else if (action == "Steal")
                {
                    int count = int.Parse(tokens[1]);
                    List<string> stealItems = new List<string>();

                    if (count <= chest.Count)
                    {
                        for (int i = chest.Count - count; i < chest.Count; i++)
                        {
                            stealItems.Add(chest[i]);
                        }
                        Console.WriteLine(string.Join(", ", stealItems));

                        chest.RemoveRange(chest.Count - count, count);
                    }
                    else
                    {
                        for (int i = 0; i < chest.Count; i++)
                        {
                            stealItems.Add(chest[i]);
                        }
                        Console.WriteLine(string.Join(", ", stealItems));

                        chest.RemoveRange(0, chest.Count);
                    }
                }
            }

            PrintResult(chest);
        }

        private static void PrintResult(List<string> chest)
        {
            double sum = 0;

            foreach (var item in chest)
            {
                sum += item.Length;
            }
            if (chest.Count != 0)
            {
                double averageGain = sum / chest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
