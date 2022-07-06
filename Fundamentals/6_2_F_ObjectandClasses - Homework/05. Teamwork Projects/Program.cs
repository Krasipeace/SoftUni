using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Team
    {
        public string Name { get; set; }
        public string Leader { get; set; }
        public List<string> Members { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            TeamInitialization(numberOfTeams, teams);

            var tokens = Console.ReadLine().Split("->").ToArray();
            tokens = MemberInitialization(teams, tokens);

            var validTeam = teams.Where(x => x.Members.Count > 0);
            var disbandTeam = teams.Where(k => k.Members.Count == 0);
            
            PrintValidTeams(validTeam);

            PrintDisbandedTeams(disbandTeam);

        }

        private static void PrintDisbandedTeams(IEnumerable<Team> disbandTeam)
        {
            Console.WriteLine($"Teams to disband:");
            foreach (var team in disbandTeam.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{team.Name}");
            }
        }

        private static void PrintValidTeams(IEnumerable<Team> validTeam)
        {
            foreach (var team in validTeam.OrderByDescending(x => x.Members.Count).ThenBy(n => n.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Leader}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }

        private static string[] MemberInitialization(List<Team> teams, string[] tokens)
        {
            while (tokens[0] != "end of assignment")
            {
                string teamMember = tokens[0];
                string joinTheTeam = tokens[1];

                if (teams.All(x => x.Name != joinTheTeam))
                {
                    Console.WriteLine($"Team {joinTheTeam} does not exist!");
                }
                else if (teams.Any(x => x.Members.Contains(teamMember) || teams.Any(x => x.Leader == teamMember)))
                {
                    Console.WriteLine($"Member {teamMember} cannot join team {joinTheTeam}!");
                }
                else
                {
                    var team = teams.Find(x => x.Name == joinTheTeam);
                    team.Members.Add(teamMember);
                }
                tokens = Console.ReadLine().Split("->");
            }

            return tokens;
        }

        private static void TeamInitialization(int numberOfTeams, List<Team> teams)
        {
            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] command = Console.ReadLine().Split("-");
                string creator = command[0];
                string teamName = command[1];

                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(x => x.Leader == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    var team = new Team();
                    team.Name = teamName;
                    team.Leader = creator;
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
        }
    }
}
