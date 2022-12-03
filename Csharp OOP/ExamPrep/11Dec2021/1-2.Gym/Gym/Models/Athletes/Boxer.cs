using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int INITIAL_STAMINA = 60;
        private const int STAMINA_MODIFIER = 15;
        private const int STAMINA_MAX_VALUE = 100;

        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
        {
        }

        public override void Exercise()
        {
            Stamina += STAMINA_MODIFIER;
            if (Stamina > STAMINA_MAX_VALUE)
            {
                Stamina = STAMINA_MAX_VALUE;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
