using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            while(true)
            {
                string resource = Console.ReadLine();
                if (resource.Equals("stop"))
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(resource))
                {
                    dictionary.Add(resource, 0);
                }

                dictionary[resource] += quantity;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
