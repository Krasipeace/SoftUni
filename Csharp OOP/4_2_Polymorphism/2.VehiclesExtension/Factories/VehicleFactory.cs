
namespace Vehicles.Factories
{
    using Factories.Contracts;
    using Models;

    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
        }

        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            switch (vehicleType)
            {
                case "Car":
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "Truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "Bus":
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                default:
                    break;
            }

            return vehicle;
        }
    }
}
