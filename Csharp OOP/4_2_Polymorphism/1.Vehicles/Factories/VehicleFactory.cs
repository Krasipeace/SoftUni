
namespace Vehicles.Factories
{
    using System;

    using Exceptions;
    using Factories.Contracts;
    using Models;
    using Models.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
        }

        public IVehicle CreateVehicle(string typeVehicle, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle;
            switch (typeVehicle)
            {
                case "Car":
                    vehicle = new Car(fuelQuantity, fuelConsumption);
                    break;
                case "Truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption);
                    break;
                default:
                    throw new Exception(ExceptionMessages.InvalidVehicleTypeExceptionMessage);
            }

            return vehicle;
        }
    }
}
