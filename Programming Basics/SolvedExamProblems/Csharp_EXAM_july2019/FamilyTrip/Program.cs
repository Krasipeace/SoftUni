using System;

namespace FamilyTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int extraTax = int.Parse(Console.ReadLine());
            double discount = 0;
            double priceNights = 0;
            double unforeseen = 0;
            
            if (nights > 7)
            {
                discount = pricePerNight - pricePerNight * 0.05; 
                priceNights = nights * discount;
            }
            else
            {
                priceNights = nights * pricePerNight;
            }
            
            unforeseen = budget * extraTax / 100;
           
            double result = priceNights + unforeseen;
            if (result <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {Math.Abs(budget - result):f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(result - budget):f2} leva needed.");
            }
        }
    }
}
