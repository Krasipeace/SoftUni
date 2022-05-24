using System;

namespace Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litres = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double fuel = litres * 2.10;
            double all = fuel + 100;

            if (day == "Saturday")
            {
                all = all - all * 0.10;
            }
            else if (day == "Sunday")
            {
                all = all - all * 0.20;
            }
            
            if (budget >= all)
            {
                Console.WriteLine($"Safari time! Money left: {budget - all:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {all - budget:f2} lv.");
            }

        }
    }
}
