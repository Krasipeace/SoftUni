using System;
using System.Collections.Generic;
using System.Linq;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }
        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            const double NEEDED_RATING = 80;
            if (string.IsNullOrEmpty(player.Name))
            {
                return "Invalid player's information.";
            }
            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < NEEDED_RATING)
            {
                return "Invalid player's rating.";
            }
            Players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (Players.Any(x => x.Name == name))
            {
                Players.Remove(Players.Find(x => x.Name == name));
                OpenPositions++;

                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = Players.RemoveAll(x => x.Position == position);
            OpenPositions += count;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            if (Players.Any(x => x.Name == name))
            {
                var toRetire = Players.Find(x => x.Name == name);
                toRetire.Retired = true;

                return toRetire;
            }
            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            var list = Players.Where(x => x.Games >= games).ToList();

            return list;
        }

        public string Report()
        {
            return $"Active players completing for Team {Name} from Group {Group}:" + Environment.NewLine +
                string.Join(Environment.NewLine, Players.FindAll(x => !x.Retired)).Trim();
        }
    }
}
