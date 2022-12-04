namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;

    public class Map : IMap
    {     
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            IRacer winner = null;
            IRacer loser = null;

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerTwo.IsAvailable())
            {
                winner = racerOne;
                loser = racerTwo;
            }
            else if (!racerOne.IsAvailable())
            {
                winner = racerTwo;
                loser = racerOne;
            }

            if (winner != null)
            {
                winner.Race();

                return string.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, loser.Username);
            } 
            
            racerOne.Race();
            racerTwo.Race();
            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * GetBehaviorValue(racerOne.RacingBehavior);
            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * GetBehaviorValue(racerTwo.RacingBehavior);

            winner = racerOneChance > racerTwoChance ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }

        private double GetBehaviorValue(string racingBehavior)
        {
            return racingBehavior == "strict" ? 1.2 : 1.1;
        }
    }
}
