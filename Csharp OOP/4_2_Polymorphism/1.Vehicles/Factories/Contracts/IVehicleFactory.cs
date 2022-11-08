namespace Vehicles.Factories.Contracts
{
    using Models.Contracts;
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string typeVehicle, double fuelQuantity, double fuelConsumption);
    }
}
