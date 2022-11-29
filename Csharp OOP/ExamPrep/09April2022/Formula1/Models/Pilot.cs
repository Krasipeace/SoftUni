namespace Formula1.Models
{
    using System;
    using System.Text;
    using Contracts;

    public class Pilot : IPilot
    {
        private string fullName;
        private int numberOfWins;
        private IFormulaOneCar car;
        private bool canRace;
        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(Utilities.ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return car;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(Utilities.ExceptionMessages.InvalidCarForPilot));
                }
                car = value;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return numberOfWins;
            }
            private set
            {
                numberOfWins = value;
            }
        }
        public bool CanRace
        {
            get
            {
                return canRace;
            }
            private set
            {
                canRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace() => numberOfWins++;

        //public override string ToString()
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.AppendLine($"Pilot {fullName} has {numberOfWins} wins.");

        //    return stringBuilder.ToString().Trim();
        //}
    }
}
