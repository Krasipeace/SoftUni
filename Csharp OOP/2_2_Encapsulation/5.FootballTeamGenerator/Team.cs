using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        private Team()
        {
            players = new List<Player>();
        }
        public Team(string name) : this()
        {
            Name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NAME_CANNOT_BE_NULL_OR_WHITESPACE);
                }
                name = value;
            }
        }
        public int Rating 
            => players.Count > 0 
            ? (int)Math.Round(players.Average(p => p.PlayerSkillLevel)) 
            : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PLAYER_CANNOT_BE_REMOVED, playerName, Name));
            }
            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
