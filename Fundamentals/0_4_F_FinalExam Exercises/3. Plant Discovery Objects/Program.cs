using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Plant_Discovery_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();

            int inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                string[] plantData = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantData[0];
                int plantRarity = int.Parse(plantData[1]);

                Plant plant = new Plant()
                {
                    Name = plantName,
                    Rarity = plantRarity,
                    TotalRating = 0
                };

                if (plant == plants.Find(p => p.Name == plantName))
                {
                    plant.Rarity = plantRarity;
                }
                else
                {
                    plants.Add(plant);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Exhibition")
                {
                    break;
                }
                string[] inputData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = inputData[0];
                string plantName = inputData[1];

                if (plants.Any(p => p.Name == plantName))
                {
                    switch (action)
                    {
                        case "Rate:":
                            Rate(plants, inputData, plantName);
                            break;
                        case "Update:":
                            Update(plants, inputData, plantName);
                            break;
                        case "Reset:":
                            Reset(plants, plantName);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("error");                    
                }

            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant item in plants)
            {
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarity}; Rating: {item.AverageRating():f2}");
            }
        }

        private static void Rate(List<Plant> plants, string[] inputData, string plantName)
        {
            double rate = double.Parse(inputData[3]);
            Plant plant = plants.Find(p => p.Name == plantName);

            plant.RateCounter++;
            plant.TotalRating += rate;
        }

        private static void Update(List<Plant> plants, string[] inputData, string plantName)
        {
            int newRarity = int.Parse(inputData[3]);
            Plant plant = plants.Find(p => p.Name == plantName);

            plant.Rarity = newRarity;
        }

        private static void Reset(List<Plant> plants, string plantName)
        {
            Plant plant = plants.Find(p => p.Name == plantName);

            plant.TotalRating = 0.0;
            plant.RateCounter = 0;
        }

    }
    public class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public double RateCounter { get; set; }
        public double TotalRating { get; set; }
        public double AverageRating()
        {
            if (RateCounter > 0 && TotalRating > 0)
            {
                return TotalRating / RateCounter;
            }
            else
            {
                return 0;
            }

        }
    }
}
