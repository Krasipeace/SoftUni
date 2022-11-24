namespace Vehicles.Exceptions
{
    using System;

    public class InvalidAmountOfRefuelFuelException : Exception
    {
        public InvalidAmountOfRefuelFuelException(string message) : base(message)
        {
        }
    }
}
