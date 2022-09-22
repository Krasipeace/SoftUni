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

            string apparelType, apparelColor;
            SearchApparel(out apparelType, out apparelColor);

            PrintClothes(allClothes, apparelType, apparelColor);
        }

        static void SearchApparel(out string apparelType, out string apparelColor)
        {
            string[] clothToSearch = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            apparelType = clothToSearch[0];
            apparelColor = clothToSearch[1];
        }

        static void PrintClothes(Dictionary<string, Dictionary<string, int>> allClothes, string apparelType, string apparelColor)
        {
            foreach (var apparel in allClothes) //main dictionary
            {
                Console.WriteLine($"{apparel.Key} clothes:");
                foreach (var apparelCount in apparel.Value)  //inner dictionary
                {
                    string printResult = $"* {apparelCount.Key} - {apparelCount.Value}";

                    if (apparel.Key == apparelType && apparelCount.Key == apparelColor)  //searched apparel
                    {
                        printResult += " (found!)";
                    }

                    Console.WriteLine(printResult);
                }
            }
        }
    }
}
