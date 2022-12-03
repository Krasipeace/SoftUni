namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int INITIAL_STAMINA = 60;
        private const int STAMINA_MODIFIER = 15;

        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
        {
        }

        public override void Exercise()
        {
            Stamina += STAMINA_MODIFIER;
        }
    }
}
