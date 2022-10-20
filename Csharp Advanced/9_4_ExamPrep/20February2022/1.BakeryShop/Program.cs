using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ").Select(w => double.Parse(w)).ToArray());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ").Select(f => double.Parse(f)).ToArray());

            Dictionary<string, int> countProducts = new Dictionary<string, int>
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };

            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Peek();
                double currentFlour = flour.Peek();

                double[] percents = new double[2];
                double fullValue = currentWater + currentFlour;
                percents[0] = currentWater / fullValue * 100.0;
                percents[1] = currentFlour / fullValue * 100.0;

                switch (percents[0])
                {
                    case 50:
                        countProducts["Croissant"]++;
                        water.Dequeue();
                        flour.Pop();
                        break;
                    case 40:
                        countProducts["Muffin"]++;
                        water.Dequeue();
                        flour.Pop();
                        break;
                    case 30:
                        countProducts["Baguette"]++;
                        water.Dequeue();
                        flour.Pop();
                        break;
                    case 20:
                        countProducts["Bagel"]++;
                        water.Dequeue();
                        flour.Pop();
                        break;
                    default:
                        countProducts["Croissant"]++;
                        flour.Push(flour.Pop() - water.Dequeue());
                        break;
                }
            }

            foreach (var item in countProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            if (water.Count != 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Count != 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
