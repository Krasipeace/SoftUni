using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "Revision")
                {
                    break;
                }
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                shops[shop].Add(product, price);


                command = Console.ReadLine();
            }
            var orderedList = shops.OrderBy(s => s.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var currShop in orderedList)
            {
                Console.WriteLine($"{currShop.Key}->");
                foreach (var item in currShop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
