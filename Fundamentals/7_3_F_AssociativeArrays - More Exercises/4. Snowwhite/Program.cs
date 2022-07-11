using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarves = new Dictionary<string, int>();

            ReadAndAddDwarves(dwarves);

            PrintResult(dwarves);
        }

        private static void ReadAndAddDwarves(Dictionary<string, int> dwarves)
        {
            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] tokens = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string hairColor = tokens[1];
                string name = tokens[0];
                int physics = int.Parse(tokens[2]);

                string key = $"({hairColor}) {name}";

                if (!dwarves.ContainsKey(key))
                {
                    dwarves.Add(key, 0);
                }

                if (dwarves[key] < physics)
                {
                    dwarves[key] = physics;
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintResult(Dictionary<string, int> dwarves)
        {
            foreach (var dwarf in dwarves.OrderByDescending(d => d.Value).ThenByDescending(color => dwarves.Where(d => d.Key.Split(")")[0] == color.Key.Split(")")[0]).Count()))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
            }
        }
    }
}
