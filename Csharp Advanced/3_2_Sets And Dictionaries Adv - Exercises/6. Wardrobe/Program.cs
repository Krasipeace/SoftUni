using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> allClothes = new Dictionary<string, Dictionary<string, int>>();

            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];

                if (!allClothes.ContainsKey(color))
                {
                    allClothes[color] = new Dictionary<string, int>();
                }

                for (int j = 1; j < tokens.Length; j++) //current color -> clothes [count]
                {
                    if (!allClothes[color].ContainsKey(tokens[j]))
                    {
                        allClothes[color].Add(tokens[j], 0);
                    }
                    allClothes[color][tokens[j]]++;
                }
            }

            string[] clothToSearch = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string apparelType = clothToSearch[0];
            string apparelColor = clothToSearch[1];

            foreach (var apparel in allClothes) //main dictionary
            {
                Console.WriteLine($"{apparel.Key} clothes:");
                foreach (var apparelCount in apparel.Value)  //inner dictionary
                {
                    string printResult = $"* {apparelCount.Key} - {apparelCount.Value}";

                    if (apparel.Key == apparelType && apparelCount.Key == apparelColor)
                    {
                        printResult += " (found!)";
                    }

                    Console.WriteLine(printResult);
                }
            }
        }
    }
}
