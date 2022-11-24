namespace Vehicles.Exceptions
{
    public static class ExceptionMessages
    {
        public const string InsufficientFuelExceptionMessage = "{0} needs refueling";

        public const string InvalidVehicleTypeExceptionMessage = "Vehicle type not supported!";

        public const string InvalidAmountOfFuel = "Fuel must be a positive number";

        public const string InvalidTankCapacity = "Cannot fit {0} fuel in the tank";
    }
}
