using System;
using System.Collections.Generic;

namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, Dictionary<string, List<string>>>();
            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!countries.ContainsKey(continent))
                {
                    countries[continent] = new Dictionary<string, List<string>>();
                }
                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent][country] = new List<string>();
                }
                countries[continent][country].Add(city);
            }

            foreach (var (continentName, countryList) in countries)
            {
                Console.WriteLine($"{continentName}:");
                foreach (var (countryName, cities) in countryList)
                {
                    Console.WriteLine($"{countryName} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
