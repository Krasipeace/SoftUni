namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelIncreasment => FuelConsumptionIncrement;

        public string DriveEmpty(double distance)
        {
            if (this.FuelQuantity - (this.FuelConsumption - FuelConsumptionIncrement) * distance >= 0)
            {
                this.FuelQuantity -= (this.FuelConsumption - FuelConsumptionIncrement) * distance;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
    }
}
