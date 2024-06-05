using System;

namespace Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            double spendCash = 0.0;
            string place = "";

            if (budget <= 100.00)
            {
                if (season == "summer")
                {
                    spendCash = budget - (budget * 0.30);
                    place = "Camp";
                }
                else if (season == "winter")
                {
                    spendCash = budget - (budget * 0.70);
                    place = "Hotel";
                }
                destination = "Bulgaria";
            }
            else if (budget <= 1000.00)
            {
                if (season == "summer")
                {
                    spendCash = budget - (budget * 0.40);
                    place = "Camp";
                }
                else if (season == "winter")
                {
                    spendCash = budget - (budget * 0.80);
                    place = "Hotel";
                }
                destination = "Balkans";
            }
            else
            {
                spendCash = budget - (budget * 0.90);
                destination = "Europe";
                place = "Hotel"; 
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {budget - spendCash:f2}");
        }
    }
}
