using System;

namespace AgencyProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            int ticketsAdult = int.Parse(Console.ReadLine());
            int ticketsKids = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double profit = 0;

            double priceKids = ticketPrice - (ticketPrice * 0.70);
            ticketPrice = ticketPrice + tax;
            priceKids = priceKids + tax;
            double finalPrice = (ticketPrice * ticketsAdult) + (priceKids * ticketsKids);
            profit = finalPrice - (finalPrice * 0.80);
            Console.WriteLine($"The profit of your agency from {companyName} tickets is {profit:f2} lv.");
        }
    }
}
