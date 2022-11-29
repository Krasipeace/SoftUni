namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Repositories;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(x => x.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            Pilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return string.Format(Utilities.OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.CarExistErrorMessage, model));
            }
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar car = null;
            switch (type)
            {
                case "Ferrari":
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    break;
                case "Williams":
                    car = new Williams(model, horsepower, engineDisplacement);
                    break;
            }
            carRepository.Add(car);

            return string.Format(Utilities.OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(x => x.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            Race race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return string.Format(Utilities.OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilotRepository.Models.Any(x => x.FullName == pilotName) || pilotRepository.Models.First(x => x.FullName == pilotName).CanRace)
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (!carRepository.Models.Any(x => x.Model == carModel))
            {
                throw new NullReferenceException(string.Format(Utilities.ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            IPilot pilot = pilotRepository.Models.First(x => x.FullName == pilotName);
            IFormulaOneCar car = carRepository.Models.First(x => x.Model == carModel);
            pilot.AddCar(car);
            carRepository.Remove(car);

            return string.Format(Utilities.OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (!raceRepository.Models.Any(x => x.RaceName == raceName))
            {
                throw new NullReferenceException(string.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            IRace race = raceRepository.Models.First(x => x.RaceName == raceName);

            if (!pilotRepository.Models.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            IPilot pilot = pilotRepository.Models.First(x => x.FullName == pilotFullName);

            if ((!pilot.CanRace) || race.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);

            return string.Format(Utilities.OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(Utilities.ExceptionMessages.RaceTookPlaceErrorMessage));
            }

            IOrderedEnumerable<IPilot> winners = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps));
            IPilot firstPlace = winners.First();
            IPilot secondPlace = winners.Skip(1).First();
            IPilot thirdPlace = winners.Skip(2).First();

            firstPlace.WinRace();
            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {firstPlace.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {secondPlace.FullName} is second in the {raceName}");
            sb.AppendLine($"Pilot {thirdPlace.FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            List<IRace> races = raceRepository.Models.Where(x => x.TookPlace).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in races)
            {
                sb.AppendLine(item.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            List<IPilot> scoreBoard = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in scoreBoard)
            {
                sb.AppendLine($"Pilot {item.FullName} has {item.NumberOfWins} wins.");
            }

            return sb.ToString().Trim();
        }

    }
}
