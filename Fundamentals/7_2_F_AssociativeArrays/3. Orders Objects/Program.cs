using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Orders_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();

            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] inputLines = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string productName = inputLines[0];
                decimal productPrice = decimal.Parse(inputLines[1]);
                int productQuantity = int.Parse(inputLines[2]);

                Order order = new Order()
                {
                    Name = productName,
                    Price = productPrice,
                    Quantity = productQuantity
                };

                if (orders.Any(o => o.Name == productName))
                {
                    orders.Select(x =>
                    {
                        if (x.Name == productName)
                            x.Price = productPrice;
                        return x;
                    }).ToList();
                    orders.Select(x =>
                    {
                        if (x.Name == productName)
                            x.Quantity += productQuantity;
                        return x;
                    }).ToList();
                }
                else
                {
                    orders.Add(order);
                }

                input = Console.ReadLine();
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Name} -> {item.TotalPrice():f2}");
            }
        }
    }

    public class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice()
        {
            return Price * Quantity;
        }
    }
}
