using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();

            string inputTowns = Console.ReadLine();
            while (inputTowns != "Sail")
            {
                string[] townInfo = inputTowns.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string townName = townInfo[0];
                int townPopulation = int.Parse(townInfo[1]);
                int townGold = int.Parse(townInfo[2]);

                Town town = new Town()
                {
                    Name = townName,
                    Population = townPopulation,
                    Gold = townGold
                };

                if (towns.Any(t => t.Name == townName))
                {
                    towns.Select(x =>
                    {
                        if (x.Name == townName) 
                            x.Population += townPopulation;
                        return x;
                    }).ToList();
                    towns.Select(x =>
                    {
                        if (x.Name == townName)
                            x.Gold += townGold;
                        return x;
                    }).ToList();
                }
                else
                {
                    towns.Add(town);
                }

                inputTowns = Console.ReadLine();
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] action = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                switch (action[0])
                {
                    case "Plunder":
                        {
                            string plunderTown = action[1];
                            int killPeople = int.Parse(action[2]);
                            int plunderGold = int.Parse(action[3]);

                            Town town = towns.Find(t => t.Name == plunderTown);

                            town.Population -= killPeople;
                            town.Gold -= plunderGold;

                            if (town.Population <= 0 || town.Gold <= 0)
                            {
                                towns.Remove(town);
                                Console.WriteLine($"{town.Name} plundered! {plunderGold} gold stolen, {killPeople} citizens killed.");
                                Console.WriteLine($"{town.Name} has been wiped off the map!");
                            }
                            else
                            {
                                Console.WriteLine($"{town.Name} plundered! {plunderGold} gold stolen, {killPeople} citizens killed.");
                            }
                        }
                        break;
                    case "Prosper":
                        {
                            string addToTown = action[1];
                            int addGold = int.Parse(action[2]);

                            Town town = towns.Find(t => t.Name == addToTown);
                            if (addGold >= 0)
                            {
                                town.Gold += addGold;
                                Console.WriteLine($"{addGold} gold added to the city treasury. {town.Name} now has {town.Gold} gold.");
                            }
                            else
                            {
                                Console.WriteLine($"Gold added cannot be a negative number!");
                            }
                        }
                        break;
                }
            }

            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (Town aliveTown in towns)
                {
                    Console.WriteLine($"{aliveTown.Name} -> Population: {aliveTown.Population} citizens, Gold: {aliveTown.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
    public class Town
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
