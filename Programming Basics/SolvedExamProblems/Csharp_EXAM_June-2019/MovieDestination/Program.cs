using System;

namespace MovieDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double price = 0;

            if (destination == "Dubai")
            {
                if (season == "Winter")
                {
                    price = days * 45000;
                }
                else if (season == "Summer")
                {
                    price = days * 40000;
                }
                price -= price * 0.30;
            }   
            else if (destination == "Sofia")
            {
                if (season == "Winter")
                {
                    price = days * 17000;
                }
                else if (season == "Summer")
                {
                    price = days * 12500;
                }
                price += price * 0.25;
            }
            else if (destination == "London")
            {
                if (season == "Winter")
                {
                    price = days * 24000;
                }
                else if (season == "Summer")
                {
                    price = days * 20250;
                }
            }

            if (price <= budget)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget - price:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {price - budget:f2} leva more!");
            }

        }
    }
}
