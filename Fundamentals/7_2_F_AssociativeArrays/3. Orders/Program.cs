using System;
using System.Collections.Generic;

namespace _3._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> orders = new Dictionary<string, double>();
            Dictionary<string, int> newOrders = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] command = input.Split();
                string name = command[0];
                double price = double.Parse(command[1]);
                int quantity = int.Parse(command[2]);

                if (!orders.ContainsKey(name))
                {
                    orders.Add(name, price);
                    newOrders.Add(name, quantity);
                }
                else if (orders.ContainsKey(name))
                {
                    orders.Remove(name);
                    orders.Add(name, price);
                    newOrders[name] += quantity;
                }

                input = Console.ReadLine();
            }
            foreach (var order in orders)
            {
                foreach (var newOrder in newOrders)
                {
                    if (order.Key == newOrder.Key)
                    {
                        Console.WriteLine($"{order.Key} -> {order.Value * newOrder.Value:f2}");
                    }
                }
            }

        }
    }
}
