using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<type>[A,D])![^@\-!:>]*->(?<soldiers>[\d]+)";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int encryptedMessages = int.Parse(Console.ReadLine());
            for (int i = 0; i < encryptedMessages; i++)
            {
                string message = Console.ReadLine();
                int starLetters = message.ToLower().Count(letter => letter == 's' 
                                                                 || letter == 't' 
                                                                 || letter == 'a'
                                                                 || letter == 'r');
                string decryptedMessage = string.Empty;
                foreach (var currentLetter in message)
                {
                    decryptedMessage += (char)(currentLetter - starLetters);
                }

                Match match = Regex.Match(decryptedMessage, pattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    //int population = int.Parse(match.Groups["population"].Value);
                    string type = match.Groups["type"].Value;
                    //int soldiers = int.Parse(match.Groups["soldiers"].Value);

                    if (type == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else if (type == "D")
                    {
                        destroyedPlanets.Add(name);
                    }
                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.OrderBy(x => x).ToList().ForEach(planetName => Console.WriteLine($"-> {planetName}"));
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.OrderBy(x => x).ToList().ForEach(planetName => Console.WriteLine($"-> {planetName}"));

        }
    }
}
