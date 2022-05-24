using System;

namespace SummerOutfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if (timeOfDay == "Morning")
            {
                if (degrees >= 10 && degrees <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (degrees > 18 && degrees <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (timeOfDay == "Afternoon")
            {
                if (degrees >=10 && degrees <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (degrees > 18 && degrees <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }
            else 
            {
                outfit = "Shirt";
                shoes = "Moccasins";
            }
            //"It's {градуси} degrees, get your {облекло} and {обувки}."
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
