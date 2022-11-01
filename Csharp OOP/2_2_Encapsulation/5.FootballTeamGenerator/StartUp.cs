using System;
using System.Collections.Generic;
using System.Linq;
//Composite wanna-be
namespace FootballTeamGenerator
{
    public class StartUp
    {
        private static List<Team> teams;
        static void Main(string[] args)
        {
            teams = new List<Team>();

            RunEngine();
        }

        static void RunEngine()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(";");
                string commandType = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (commandType)
                    {
                        case "Team":
                            {
                                AddTeam(teamName);
                                break;
                            }
                        case "Add":
                            {
                                AddPlayerToTeam(tokens, teamName);
                                break;
                            }
                        case "Remove":
                            {
                                RemovePlayerFromTeam(tokens, teamName);
                                break;
                            }
                        case "Rating":
                            {
                                GetRating(teamName);
                                break;
                            }
                    }
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
                catch (InvalidOperationException inv)
                {
                    Console.WriteLine(inv.Message);
                }

                command = Console.ReadLine();
            }
        }

        static void AddTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teams.Add(newTeam);
        }

        static void AddPlayerToTeam(string[] tokens, string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TEAM_DOES_NOT_EXIST, teamName));
            }
            string playerName = tokens[2];
            int endurance = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);

            Player addedPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(addedPlayer);
        }

        static void RemovePlayerFromTeam(string[] tokens, string teamName)
        {
            string playerName = tokens[2];
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (playerName == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TEAM_DOES_NOT_EXIST, teamName));
            }
            team.RemovePlayer(playerName);
        }

        static void GetRating(string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TEAM_DOES_NOT_EXIST, teamName));
            }
            Console.WriteLine(team.ToString());
        }
    }
}
