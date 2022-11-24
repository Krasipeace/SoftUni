namespace Vehicles.Factories.Contracts
{
    using Vehicles.Models;

    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
