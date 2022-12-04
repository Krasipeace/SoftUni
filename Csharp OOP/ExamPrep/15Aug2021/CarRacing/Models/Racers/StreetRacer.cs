namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    public class StreetRacer : Racer
    {
        private const string RACING_BEHAVIOR = "aggressive";
        private const int RACING_EXPERIENCE = 10;
        private const int EXPERIENCE_MODIFIER = 5;

        public StreetRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, RACING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += EXPERIENCE_MODIFIER;
        }
    }
}
