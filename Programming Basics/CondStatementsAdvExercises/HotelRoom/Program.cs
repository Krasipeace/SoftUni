using System;

namespace HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double priceStudio = 0.0;
            double priceAp = 0.0;

            if (month == "May" || month == "October")
            {
                priceStudio = nights * 50.0;
                if (nights > 14)
                {
                    priceStudio = priceStudio - priceStudio * 0.30;
                }
                else if (nights > 7)
                {
                    priceStudio = priceStudio - priceStudio * 0.05;
                }
                priceAp = nights * 65.0;
                if (nights > 14)
                {
                    priceAp = priceAp - priceAp * 0.10;
                }
                Console.WriteLine($"Apartment: {priceAp:f2} lv.");
                Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = nights * 75.20;
                if (nights > 14)
                {
                    priceStudio = priceStudio - priceStudio * 0.20;
                }
                priceAp = nights * 68.70;
                if (nights > 14)
                {
                    priceAp = priceAp - priceAp * 0.10;
                }
                Console.WriteLine($"Apartment: {priceAp:f2} lv.");
                Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = nights * 76.0;
                priceAp = nights * 77.0;
                if (nights > 14)
                {
                    priceAp = priceAp - priceAp * 0.10;
                }
                Console.WriteLine($"Apartment: {priceAp:f2} lv.");
                Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            }

        }

    }

}
