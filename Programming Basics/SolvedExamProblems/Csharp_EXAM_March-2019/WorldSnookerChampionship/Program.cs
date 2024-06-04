using System;

namespace WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            char pic = char.Parse(Console.ReadLine());

            double ticketPrice = 0;
            double trophyPics = tickets * 40.0;

            if (stage == "Quarter final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = tickets * 55.50;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = tickets * 105.20;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = tickets * 118.90;
                }
            }
            else if (stage == "Semi final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = tickets * 75.88;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = tickets * 125.22;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = tickets * 300.40;
                }
            }
            else if (stage == "Final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = tickets * 110.10;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = tickets * 160.66;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = tickets * 400.0;
                }
            }
            if (ticketPrice > 4000)
            {
                ticketPrice -= ticketPrice * 0.25;
                pic = 'N';
            }
            else if (ticketPrice > 2500 && ticketPrice <= 4000)
            {
                ticketPrice -= ticketPrice * 0.10;          
            }

            if (pic == 'Y')
            {
                ticketPrice += trophyPics;                    
            }             
            
            Console.WriteLine($"{ticketPrice:f2}");
        }
    }
}
