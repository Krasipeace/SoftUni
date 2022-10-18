using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DIPPING_SAUCE = 150;
            const int GREEN_SALAD = 250;
            const int CHOCOLATE_CAKE = 300;
            const int LOBSTER = 400;
            const int INCREASE_VALUE = 5;
            int sauces = 0;
            int salads = 0;
            int cakes = 0;
            int lobsters = 0;

            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ").Select(f => int.Parse(f)).ToArray());

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();

                    continue;
                }

                int dish = ingredients.Peek() * freshness.Peek();

                switch (dish)
                {
                    case DIPPING_SAUCE:
                        sauces++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case GREEN_SALAD:
                        salads++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case CHOCOLATE_CAKE:
                        cakes++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case LOBSTER:
                        lobsters++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    default:
                        freshness.Pop();
                        ingredients.Enqueue(ingredients.Dequeue() + INCREASE_VALUE);
                        break;
                }
            }

            if (sauces > 0 && salads > 0 && cakes > 0 && lobsters > 0)
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                {"Chocolate cake",cakes},
                {"Dipping sauce",sauces},
                {"Green salad",salads},
                {"Lobster",lobsters},
            };

            dishes.OrderBy(x => x.Key);
            foreach (var item in dishes)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
