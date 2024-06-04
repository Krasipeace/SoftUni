using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Go Shopping!")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Urgent":
                        Urgent(tokens[1], list);                         //add item at the start of the list
                        break;
                    case "Unnecessary":
                        Unnecessary(tokens[1], list);                    //remove item
                        break;
                    case "Correct":
                        Correct(tokens[1], tokens[2], list);             //change name of item
                        break;
                    case "Rearrange":
                        Rearrange(tokens[1], list);                      //remove item from current position and add it to the end of the list
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", list));
        }

        private static void Rearrange(string item, List<string> list)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                list.Add(item);
            }
        }

        private static void Correct(string oldItemName, string newItemName, List<string> list)
        {
            if (list.Contains(oldItemName))
            {
                int positionOfItem = list.IndexOf(oldItemName);
                list.Insert(positionOfItem, newItemName);
                list.Remove(oldItemName);
            }
        }

        private static void Unnecessary(string item, List<string> list)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
            }
        }

        private static void Urgent(string item, List<string> list)
        {
            if (!list.Contains(item))
            {
                list.Insert(0, item);
            }
        }
    }
}
