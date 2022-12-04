namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string RACING_BEHAVIOR = "strict";
        private const int RACING_EXPERIENCE = 30;
        private const int EXPERIENCE_MODIFIER = 10;

        public ProfessionalRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, RACING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += EXPERIENCE_MODIFIER;
        }
    }
}
