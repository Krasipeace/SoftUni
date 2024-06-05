using System;

namespace MovieProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());
            double pCinema = double.Parse(Console.ReadLine());

            double incomeTickets = days * tickets * priceTicket;
            double incomeCinema = incomeTickets - (incomeTickets * pCinema / 100.0);

            Console.WriteLine($"The profit from the movie {title} is {incomeCinema:f2} lv.");
        }
    }
}
