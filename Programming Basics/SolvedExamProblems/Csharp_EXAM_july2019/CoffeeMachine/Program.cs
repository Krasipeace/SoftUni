using System;

namespace CoffeeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();   //"Espresso", "Cappuccino" или "Tea"
            string sugar = Console.ReadLine();  //"Without", "Normal" или "Extra"
            int amount = int.Parse(Console.ReadLine());
            double price = 0;
            double finalPrice = 0;

            if (type == "Espresso")
            {
                if (sugar == "Without")
                {
                    price = 0.90 * 0.65;
                }
                else if (sugar == "Normal")
                {
                    price = 1.00;
                }
                else if (sugar == "Extra")
                {
                    price = 1.20;
                }
                if (amount >= 5)
                {
                    price = price - (price * 0.25);
                }
            }
            else if (type == "Cappuccino")
            {
                if (sugar == "Without")
                {
                    price = 1.00 * 0.65;
                }
                else if (sugar == "Normal")
                {
                    price = 1.20;
                }
                else if (sugar == "Extra")
                {
                    price = 1.60;
                }
            }
            else if (type == "Tea")
            {
                if (sugar == "Without")
                {
                    price = 0.50 * 0.65;
                }
                else if (sugar == "Normal")
                {
                    price = 0.60;
                }
                else if (sugar == "Extra")
                {
                    price = 0.70;
                }
            }
            finalPrice = price * amount;

            if (finalPrice > 15)
            {
                finalPrice = finalPrice - (finalPrice * 0.20);
            }
            
            Console.WriteLine($"You bought {amount} cups of {type} for {finalPrice:f2} lv.");
        }
    }
}
