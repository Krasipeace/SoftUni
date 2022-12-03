namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int WEIGHTLIFTING_CAPACITY = 20;
        public WeightliftingGym(string name) : base(name, WEIGHTLIFTING_CAPACITY)
        {
        }
    }
}
