using System;

namespace FilmPremiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieTitle = Console.ReadLine();
            string pack = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            double price = 0;

            if (movieTitle == "John Wick")
            {
                if (pack == "Drink")
                {
                    price = tickets * 12.0;
                }
                else if (pack == "Popcorn")
                {
                    price = tickets * 15.0;
                }
                else if (pack == "Menu")
                {
                    price = tickets * 19.0;
                }
            }
            else if (movieTitle == "Star Wars")
            {
                if (pack == "Drink")
                {
                    price = tickets * 18.0;
                }
                else if (pack == "Popcorn")
                {
                    price = tickets * 25.0;
                }
                else if (pack == "Menu")
                {
                    price = tickets * 30.0;
                }
                if (tickets >= 4)
                {
                    price -= price * 0.30;
                }
            }
            else if (movieTitle == "Jumanji")
            {
                if (pack == "Drink")
                {
                    price = tickets * 9.0;
                }
                else if (pack == "Popcorn")
                {
                    price = tickets * 11.0;
                }
                else if (pack == "Menu")
                {
                    price = tickets * 14.0;
                }
                if (tickets == 2)
                {
                    price -= price * 0.15;
                }
            }

            Console.WriteLine($"Your bill is {price:f2} leva.");
        }
    }
}
