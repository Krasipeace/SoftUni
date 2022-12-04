namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string vin, int horsePower)
        {
            ICar car;
            switch (type)
            {
                case "SuperCar":
                    car = new SuperCar(make, model, vin, horsePower);
                    break;
                case "TunedCar":
                    car = new TunedCar(make, model, vin, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, vin);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            ICar car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            switch(type)
            {
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    break;
                case "ProfessionalRacer":
                    racer = new ProfessionalRacer(username, car);
                    break;
                default: 
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            else
            {
                return map.StartRace(racerOne, racerTwo);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb
                    .AppendLine($"{item.GetType().Name}: {item.Username}")
                    .AppendLine($"--Driving behavior: {item.RacingBehavior}")
                    .AppendLine($"--Driving experience: {item.DrivingExperience}")
                    .AppendLine($"--Car: {item.Car.Make} {item.Car.Model} ({item.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
