using System;

namespace _04_TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double price;
            double allCashNeed = 0;
            int counter = 0;

            while (input != "Stop")
            {
                price = double.Parse(Console.ReadLine());                
                counter++;

                if (counter % 3 == 0)
                {
                    price *= 0.50;
                }
                allCashNeed += price;
                if (allCashNeed > budget)
                {
                    Console.WriteLine($"You don't have enough money!");
                    Console.WriteLine($"You need {allCashNeed - budget:f2} leva!");
                    break;
                }

                input = Console.ReadLine();
            }
            if (input == "Stop")
            {
                Console.WriteLine($"You bought {counter} products for {allCashNeed:f2} leva.");
            }
        }
    }
}
