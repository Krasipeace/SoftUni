namespace Vehicles.Exceptions
{
    using System;

    public class InvalidVehicleTypeException : Exception
    {
        //compile-time polymorphism
        public InvalidVehicleTypeException()
            : base(ExceptionMessages.InvalidVehicleTypeExceptionMessage)
        {
        }
        public InvalidVehicleTypeException(string message)
            : base(message)
        {
        }
    }
}