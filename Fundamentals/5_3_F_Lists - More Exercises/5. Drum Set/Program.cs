using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            List<int> drums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> price = new List<int>();
            price.AddRange(drums);
            string command = string.Empty;

            command = CalculateDrums(ref budget, drums, price);

            PrintResult(budget, drums);
        }

        private static void PrintResult(double budget, List<int> drums)
        {
            foreach (var drum in drums)
            {
                Console.Write(drum + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Gabsy has {budget:f2}lv.");
        }

        private static string CalculateDrums(ref double budget, List<int> drums, List<int> price)
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "Hit it again, Gabsy!")
                {
                    break;
                }
                int hit = int.Parse(command);

                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= hit;
                    if (drums[i] <= 0)
                    {
                        if (budget - (price[i] * 3) >= 0)
                        {
                            budget = budget - (price[i] * 3);
                            drums[i] = price[i];
                        }
                    }
                }

                for (int i = 0; i < drums.Count; i++)
                {
                    if (drums[i] <= 0)
                    {
                        drums.Remove(drums[i]);
                        price.Remove(price[i]);
                    }
                }
            }

            return command;
        }
    }
}
