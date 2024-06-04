using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Inventory
    //As a young traveler, you gather items and craft new items.
    //smells like Valheim...
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Craft!")
                {
                    break;
                }

                string[] tokens = command.Split(" - ");
                string action = tokens[0];
                string item = tokens[1];

                switch (action)
                {
                    case "Collect":
                        Collect(item, items);
                        break;
                    case "Drop":
                        Drop(item, items);
                        break;
                    case "Renew":
                        Renew(item, items);
                        break;
                    case "Combine Items":
                        Combine(item, items);
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", items));
        }

        private static void Combine(string item, List<string> items)
        {
            string[] splitter = item.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string oldItem = splitter[0];
            string newItem = splitter[1];
            int temp = items.IndexOf(oldItem);

            if (items.Contains(oldItem))
            {
                items.Insert(temp + 1, newItem);
            }
        }

        private static void Renew(string item, List<string> items)
        {
            if (items.Contains(item))
            {
                int itemPosition = items.IndexOf(item);
                items.Add(item);
                items.RemoveAt(itemPosition);
            }
        }

        private static void Drop(string item, List<string> items)
        {
            items.Remove(item);
        }

        private static void Collect(string item, List<string> items)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }
    }
}
