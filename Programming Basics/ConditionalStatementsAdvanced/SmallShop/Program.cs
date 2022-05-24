using System;

namespace SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();                   // coffee water  beer  sweets  peanuts
            string city = Console.ReadLine();                      // Sofia  Varna  Plovdiv  
            double quantity = double.Parse(Console.ReadLine());
            double cost;
            if (product == "coffee")
            {
                if (city == "Sofia")
                {
                    cost = quantity * 0.50;
                    Console.WriteLine(cost);
                }
                else if (city == "Plovdiv")
                {
                    cost = quantity * 0.40;
                    Console.WriteLine(cost);
                }
                else if (city == "Varna")
                {
                    cost = quantity * 0.45;
                    Console.WriteLine(cost);
                }
            }
            else if (product == "water")
            {
                if (city == "Sofia")
                {
                    cost = quantity * 0.80;
                    Console.WriteLine(cost);
                }
                else if ((city == "Plovdiv") || (city == "Varna"))    //water 0.70
                {
                    cost = quantity * 0.70;
                    Console.WriteLine(cost);
                }
            }
            else if (product == "beer")
            {
                if (city == "Sofia")
                {
                    cost = quantity * 1.20;
                    Console.WriteLine(cost);
                }
                else if (city == "Plovdiv")
                {
                    cost = quantity * 1.15;
                    Console.WriteLine(cost);
                }
                else if (city == "Varna")
                {
                    cost = quantity * 1.10;
                    Console.WriteLine(cost);
                }
            }
            else if (product == "sweets")
            {
                if (city == "Sofia")
                {
                    cost = quantity * 1.45;
                    Console.WriteLine(cost);
                }
                else if (city == "Plovdiv")
                {
                    cost = quantity * 1.30;
                    Console.WriteLine(cost);
                }
                else if (city == "Varna")
                {
                    cost = quantity * 1.35;
                    Console.WriteLine(cost);
                }
            }
            else if (product == "peanuts")
            {
                if (city == "Sofia")
                {
                    cost = quantity * 1.60;
                    Console.WriteLine(cost);
                }
                else if (city == "Plovdiv")
                {
                    cost = quantity * 1.50;
                    Console.WriteLine(cost);
                }
                else if (city == "Varna")
                {
                    cost = quantity * 1.55;
                    Console.WriteLine(cost);
                }
            }
        }
    }
}
