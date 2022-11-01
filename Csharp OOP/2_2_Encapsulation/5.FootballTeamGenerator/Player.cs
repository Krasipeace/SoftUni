using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NAME_CANNOT_BE_NULL_OR_WHITESPACE);
                }
                name = value;
            }
        }
        public Stats Stats { get; private set; }

        public double PlayerSkillLevel
            => (Stats.Endurance + Stats.Sprint + Stats.Dribble + Stats.Passing + Stats.Shooting) / 5.00;
    }
}
