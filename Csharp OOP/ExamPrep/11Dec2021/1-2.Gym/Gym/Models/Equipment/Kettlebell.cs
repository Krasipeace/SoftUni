namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double KETTLEBELL_WEIGHT = 10000;
        private const decimal KETTLEBELL_PRICE = 80;

        public Kettlebell() : base(KETTLEBELL_WEIGHT, KETTLEBELL_PRICE)
        {
        }
    }
}
