using System;

namespace FoodForPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodQ = double.Parse(Console.ReadLine());
            int foodDog = 0;
            int foodCat = 0;
            double foodEaten = 0;
            double bisquits = 0;
             double dogPercent = 0;
            double catPercent = 0;
            double bisquitsCounter = 0;

            for (int i = 1; i <= days; i++)
            {
                foodDog = int.Parse(Console.ReadLine());
                dogPercent += foodDog;
                foodCat = int.Parse(Console.ReadLine());
                catPercent += foodCat;
                foodEaten += foodDog + foodCat;
                if (i % 3 == 0)
                {
                    bisquits = (foodDog + foodCat) * 0.10;
                    bisquitsCounter += bisquits;
                }                
            }
            double foodPercent = foodEaten / foodQ * 100.0;
            dogPercent = dogPercent / foodEaten * 100.0;
            catPercent = catPercent / foodEaten * 100.0;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(bisquitsCounter)}gr.");
            Console.WriteLine($"{foodPercent:f2}% of the food has been eaten.");
            Console.WriteLine($"{dogPercent:f2}% eaten from the dog.");
            Console.WriteLine($"{catPercent:f2}% eaten from the cat.");
        }
    }
}
