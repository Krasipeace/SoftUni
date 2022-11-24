using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;
        private const double DamagedFuelTankModifier = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity) : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
        }

        public override double FuelIncreasment => FuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidAmountOfRefuelFuelException(ExceptionMessages.InvalidAmountOfFuel);
            }

            if (this.FuelQuantity + liters * DamagedFuelTankModifier <= this.TankCapacity)
            {
                this.FuelQuantity += liters * DamagedFuelTankModifier;
            }
            else
            {
                throw new InvalidTankCapacityException(string.Format(ExceptionMessages.InvalidTankCapacity, liters));
            }
        }
    }
}
