using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int INITIAL_STAMINA = 50;
        private const int STAMINA_MODIFIER = 10;
        private const int STAMINA_MAX_VALUE = 100;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
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
