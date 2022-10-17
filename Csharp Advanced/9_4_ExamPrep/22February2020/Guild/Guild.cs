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
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roster.Count;
      
        public void AddPlayer(Player player)
        {
            if (this.roster.Count < Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(p => p.Name == name));
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.Find(p => p.Name == name);
            if (player != null)
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.Find(p => p.Name == name);
            if (player != null)
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = this.roster.FindAll(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);

            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
