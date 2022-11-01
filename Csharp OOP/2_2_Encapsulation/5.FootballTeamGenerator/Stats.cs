using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                if (IsStatsInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.STATS_MUST_BE_0_TO_100, nameof(Endurance)));
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (IsStatsInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.STATS_MUST_BE_0_TO_100, nameof(Sprint)));
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                if (IsStatsInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.STATS_MUST_BE_0_TO_100, nameof(Dribble)));
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                if (IsStatsInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.STATS_MUST_BE_0_TO_100, nameof(Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                if (IsStatsInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.STATS_MUST_BE_0_TO_100, nameof(Shooting)));
                }
                shooting = value;
            }
        }

        private bool IsStatsInvalid(int value)
            => value < 0 || value > 100;
    }
}
