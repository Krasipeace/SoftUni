using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BREAD = 25;
            const int CAKE = 50;
            const int PASTRY = 75;
            const int FRUIT_PIE = 100;
            const int ADD_INGREDIENTS = 3;

            int breads = 0;
            int cakes = 0;
            int pastries = 0;
            int fruitPies = 0;

            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").Select(l => int.Parse(l)).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToArray());

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int cook = liquids.Peek() + ingredients.Peek();

                switch (cook)
                {
                    case BREAD:
                        breads++;
                        ingredients.Pop();
                        break;
                    case CAKE:
                        cakes++;
                        ingredients.Pop();
                        break;
                    case PASTRY:
                        pastries++;
                        ingredients.Pop();
                        break;
                    case FRUIT_PIE:
                        fruitPies++;
                        ingredients.Pop();
                        break;
                    default:
                        {
                            int leftIngredients = ingredients.Peek() + ADD_INGREDIENTS;
                            ingredients.Pop();
                            ingredients.Push(leftIngredients);
                            break;
                        }
                }
                liquids.Dequeue();
            }

            if (breads > 0 && cakes > 0 && fruitPies > 0 && pastries > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                List<int> leftLiquids = new List<int>(liquids);
                Console.WriteLine($"Liquids left: {string.Join(", ", leftLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                List<int> leftIngredients = new List<int>(ingredients);
                Console.WriteLine($"Ingredients left: {string.Join(", ", leftIngredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Dictionary<string, int> cooked = new Dictionary<string, int>
            {
                {"Bread",breads },
                {"Cake",cakes },
                {"Fruit Pie",fruitPies },
                {"Pastry",pastries },
            };

            foreach (var item in cooked)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
