using System;

namespace OscarsWeekCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieTitle = Console.ReadLine();  // A Star Is Born", "Bohemian Rhapsody","Green Book" или "The Favourite
            string room = Console.ReadLine();        //"normal", "luxury" или "ultra luxury"
            int tickets = int.Parse(Console.ReadLine());
            double price = 0;

            if (room == "normal")
            {
                if (movieTitle == "A Star Is Born")
                {
                    price = tickets * 7.50;
                }
                else if (movieTitle == "Bohemian Rhapsody")
                {
                    price = tickets * 7.35;
                }
                else if (movieTitle == "Green Book")
                {
                    price = tickets * 8.15;
                }
                else if (movieTitle == "The Favourite")
                {
                    price = tickets * 8.75;
                }
            }
            else if (room == "luxury")
            {
                if (movieTitle == "A Star Is Born")
                {
                    price = tickets * 10.50;
                }
                else if (movieTitle == "Bohemian Rhapsody")
                {
                    price = tickets * 9.45;
                }
                else if (movieTitle == "Green Book")
                {
                    price = tickets * 10.25;
                }
                else if (movieTitle == "The Favourite")
                {
                    price = tickets * 11.55;
                }
            }
            else if (room == "ultra luxury")
            {
                if (movieTitle == "A Star Is Born")
                {
                    price = tickets * 13.50;
                }
                else if (movieTitle == "Bohemian Rhapsody")
                {
                    price = tickets * 12.75;
                }
                else if (movieTitle == "Green Book")
                {
                    price = tickets * 13.25;
                }
                else if (movieTitle == "The Favourite")
                {
                    price = tickets * 13.95;
                }
            }
            Console.WriteLine($"{movieTitle} -> {price:f2} lv.");
        }
    }
}
