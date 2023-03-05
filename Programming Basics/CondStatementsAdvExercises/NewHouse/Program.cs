using System;

namespace NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // вход от конзолата
            string flowerType = Console.ReadLine();
            int flowerQ = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;

            //проверки за цветя
            switch (flowerType)
            {
                case "Roses": price = 5.00;
                    break;
                case "Dahlias": price = 3.80;
                    break;
                case "Tulips": price = 2.80;
                    break;
                case "Narcissus": price = 3.00;
                    break;
                case "Gladiolus": price = 2.50;
                    break;
            }

            double flowerCost = flowerQ * price;
            //проверки за отстъпка
            switch (flowerType)
            {
                case "Roses" when flowerQ > 80:
                    flowerCost -= flowerCost * 0.10;
                    break;
                case "Dahlias" when flowerQ > 90:
                    flowerCost -= flowerCost * 0.15;
                    break;
                case "Tulips" when flowerQ > 80:
                    flowerCost -= flowerCost * 0.15;
                    break;
                case "Narcissus" when flowerQ < 120:
                    flowerCost += flowerCost * 0.15;
                    break;
                case "Gladiolus" when flowerQ < 80:
                    flowerCost += flowerCost * 0.20;
                    break;
            }

            if (budget >= flowerCost)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerQ} {flowerType} and {budget - flowerCost:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(flowerCost - budget):f2} leva more.");
            }
        }
    }
}
