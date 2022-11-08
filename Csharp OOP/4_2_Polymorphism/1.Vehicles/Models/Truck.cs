namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;
        private const double DamagedFuelTankModifier = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, FuelConsumptionIncrement)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * DamagedFuelTankModifier);
        }
    }
}
