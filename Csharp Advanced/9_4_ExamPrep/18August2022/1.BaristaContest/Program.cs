using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CORTADO = 50;
            const int ESPRESSO = 75;
            const int CAPUCCINO = 100;
            const int AMERICANO = 150;
            const int LATTE = 200;
            const int DECREASED_VALUE = 5;

            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());

            Dictionary<string, int> completedCups = new Dictionary<string, int>()
            {
                {"Cortado", 0},
                {"Espresso", 0},
                {"Capuccino", 0},
                {"Americano", 0},
                { "Latte", 0},
            };

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currentCoffee = coffee.Dequeue();
                int currentMilk = milk.Pop();
                int mixedCup = currentCoffee + currentMilk;

                switch (mixedCup)
                {
                    case CORTADO:
                        completedCups["Cortado"]++;
                        break;
                    case ESPRESSO:
                        completedCups["Espresso"]++;
                        break;
                    case CAPUCCINO:
                        completedCups["Capuccino"]++;
                        break;
                    case AMERICANO:
                        completedCups["Americano"]++;
                        break;
                    case LATTE:
                        completedCups["Latte"]++;
                        break;
                    default:
                        milk.Push(currentMilk - DECREASED_VALUE);
                        break;
                }
            }

            switch (coffee.Count)
            {
                case 0 when milk.Count == 0:
                    Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                    break;
                default:
                    Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                    break;
            }

            if (coffee.Count <= 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milk.Count <= 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }

            foreach (var item in completedCups.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
