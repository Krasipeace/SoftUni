using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;
      
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(p => p.Name == name));
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.Find(p => p.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.Find(p => p.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = roster.FindAll(p => p.Class == @class).ToArray();
            roster.RemoveAll(p => p.Class == @class);

            return players;
        }
       
        public string Report()
            => $"Players in the guild: {this.Name}" +
               Environment.NewLine +
               string.Join(Environment.NewLine, this.roster);
    }
}
