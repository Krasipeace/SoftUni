using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> rankings = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains(" -> "))
                {
                    AddPlayer(rankings, input);
                }
                else if (input.Contains(" vs "))
                {
                    Duel(rankings, input);
                }

                input = Console.ReadLine();
            }

            PrintResult(rankings);
        }

        private static void AddPlayer(Dictionary<string, Dictionary<string, int>> rankings, string input)
        {
            string[] tokens = input.Split(" -> ");
            string name = tokens[0];
            string position = tokens[1];
            int skill = int.Parse(tokens[2]);

            if (!rankings.ContainsKey(name))
            {
                rankings.Add(name, new Dictionary<string, int>());
            }

            if (!rankings[name].ContainsKey(position))
            {
                rankings[name].Add(position, 0);
            }

            if (rankings[name][position] < skill)
            {
                rankings[name][position] = skill;
            }
        }

        private static void Duel(Dictionary<string, Dictionary<string, int>> rankings, string input)
        {
            string[] tokens = input.Split(" vs ");
            string firstPlayer = tokens[0];
            string secondPlayer = tokens[1];

            if (rankings.ContainsKey(firstPlayer) && rankings.ContainsKey(secondPlayer))
            {
                foreach (var position in rankings[firstPlayer].Keys)
                {
                    if (rankings[secondPlayer].ContainsKey(position))
                    {
                        if (rankings[firstPlayer].Values.Sum() > rankings[secondPlayer].Values.Sum())
                        {
                            rankings.Remove(secondPlayer);
                        }
                        else if (rankings[secondPlayer].Values.Sum() > rankings[firstPlayer].Values.Sum())
                        {
                            rankings.Remove(firstPlayer);
                        }
                        break;
                    }
                }
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> rankings)
        {
            foreach (var player in rankings.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var x in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {x.Key} <::> {x.Value}");
                }

            }
        }
    }
}
