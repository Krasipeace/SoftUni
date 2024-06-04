using System;

namespace EasterTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine(); //"France", "Italy" или "Germany"
            string dates = Console.ReadLine(); //"21-23", "24-27" или "28-31"
            int nights = int.Parse(Console.ReadLine());
            double price = 0;

            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    price = nights * 30;
                }
                else if (dates == "24-27")
                {
                    price = nights * 35;
                }
                else if (dates == "28-31")
                {
                    price = nights * 40;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    price = nights * 28;
                }
                else if (dates == "24-27")
                {
                    price = nights * 32;
                }
                else if (dates == "28-31")
                {
                    price = nights * 39;
                }
            }

            else if (destination == "Germany")
            {
                if (dates == "21-23")
                {
                    price = nights * 32;
                }
                else if (dates == "24-27")
                {
                    price = nights * 37;
                }
                else if (dates == "28-31")
                {
                    price = nights * 43;
                }
            }

            Console.WriteLine($"Easter trip to {destination} : {price:f2} leva.");
        }
    }
}
