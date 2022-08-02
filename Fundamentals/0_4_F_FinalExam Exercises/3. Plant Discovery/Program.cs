using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PlantData> plants = new Dictionary<string, PlantData>();
            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                List<string> inputData = Console.ReadLine().Split("<->").ToList();
                string plant = inputData[0];
                int rarity = int.Parse(inputData[1]);

                CheckPlantExistence(plants, plant, rarity);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                List<string> inputData = command.Split(" ").ToList();
                string plant = inputData[1];

                if (plants.ContainsKey(plant))
                {
                    switch (inputData[0])
                    {
                        case "Rate:":                            
                            Rate(plants, inputData, plant);
                            break;
                        case "Update:":
                            Update(plants, inputData, plant);
                            break;
                        case "Reset:":
                            Reset(plants, plant);
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            GetRating(plants);

            PrintResult(plants);
        }

        private static void CheckPlantExistence(Dictionary<string, PlantData> plants, string plant, int rarity)
        {
            if (plants.ContainsKey(plant))
            {
                plants[plant].Rarity = rarity;
            }
            else
            {
                plants.Add(plant, new PlantData(rarity, new List<int>(), 0, 0.0));
            }
        }

        private static void Rate(Dictionary<string, PlantData> plants, List<string> inputData, string plant)
        {
            if (plants.ContainsKey(plant))
            {
                int rating = int.Parse(inputData[3]);
                plants[plant].Ratings.Add(rating);
                plants[plant].TotalRating += rating;
            }
        }

        private static void Update(Dictionary<string, PlantData> plants, List<string> inputData, string plant)
        {
            if (plants.ContainsKey(plant))
            {
                int rarity = int.Parse(inputData[3]);
                plants[plant].Rarity = rarity;
            }
        }

        private static void Reset(Dictionary<string, PlantData> plants, string plant)
        {
            if (plants.ContainsKey(plant))
            {
                plants[plant].Ratings.Clear();
                plants[plant].TotalRating = 0;
            }
        }

        private static void GetRating(Dictionary<string, PlantData> plants)
        {
            foreach (var item in plants)
            {
                if (plants[item.Key].Ratings.Count == 0)
                {
                    plants[item.Key].AverageRating = 0.0;
                }
                else
                {
                    plants[item.Key].AverageRating = plants[item.Key].TotalRating * 1.0 / plants[item.Key].Ratings.Count * 1.0;
                }
            }
        }

        private static void PrintResult(Dictionary<string, PlantData> plants)
        {
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.AverageRating:f2}");
            }
        }
    }

    public class PlantData
    {
        public int Rarity;
        public List<int> Ratings;
        public int TotalRating;
        public double AverageRating;

        public PlantData(int rarity, List<int> ratings, int totalRating, double averageRating)
        {
            Rarity = rarity;
            Ratings = ratings;
            TotalRating = totalRating;
            AverageRating = averageRating;
        }
    }
}
