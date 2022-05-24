using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            string movieName = Console.ReadLine();

            while (movieName != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                int ticket = 0;
                while (input != "End")
                {
                    if (input == "student")
                    {
                        studentTickets++;
                    }
                    else if (input == "standard")
                    {
                        standardTickets++;
                    }
                    else
                    {
                        kidTickets++;
                    }
                    ticket++;

                    if (ticket == freeSeats)
                    {
                        break;
                    }
                    input = Console.ReadLine();
                }
                double occupancy = ticket * 100.00 / freeSeats;
                Console.WriteLine($"{movieName} - {occupancy:f2}% full.");
                movieName = Console.ReadLine();
            }
            int totalTickets = studentTickets + standardTickets + kidTickets;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(studentTickets * 100.00 / totalTickets):f2}% student tickets.");
            Console.WriteLine($"{(standardTickets * 100.00 / totalTickets):f2}% standard tickets.");
            Console.WriteLine($"{(kidTickets * 100.00 / totalTickets):f2}% kids tickets.");
        }
    }
}
