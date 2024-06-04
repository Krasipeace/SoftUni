using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            string product = string.Empty;
            double cash = 0.0;

            while ((input = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1)
                {
                    cash += coins;
                }
                else if (coins == 0.2)
                {
                    cash += coins;
                }
                else if (coins == 0.5)
                {
                    cash += coins;
                }
                else if (coins == 1.0)
                {
                    cash += coins;
                }
                else if (coins == 2.0)
                {
                    cash += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
            }

            while ((product = Console.ReadLine()) != "End")
            {
                if (product == "Nuts")
                {
                    if (cash < 2.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    cash -= 2.0;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (product == "Water")
                {
                    if (cash < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    cash -= 0.7;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (product == "Crisps")
                {
                    if (cash < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    cash -= 1.5;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (product == "Soda")
                {
                    if (cash < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    cash -= 0.8;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (product == "Coke")
                {
                    if (cash < 1.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                       continue;
                    }
                    cash -= 1.0;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }

            Console.WriteLine($"Change: {cash:f2}");
        }
    }
}
