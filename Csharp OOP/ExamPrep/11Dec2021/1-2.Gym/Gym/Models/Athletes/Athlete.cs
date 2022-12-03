using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;

        private const int STAMINA_MODIFIER = 15;
        private const int STAMINA_MAX_VALUE = 100;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullName = value;
            }
        }

        public string Motivation
        {
            get
            {
                return motivation;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value;
            }
        }

        public int Stamina
        {
            get
            {
                return stamina;
            }
            protected set
            {
                if (value > STAMINA_MAX_VALUE)
                {
                    stamina = STAMINA_MAX_VALUE;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }
                stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return numberOfMedals;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
