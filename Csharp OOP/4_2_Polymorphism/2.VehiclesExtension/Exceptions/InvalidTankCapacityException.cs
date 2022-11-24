namespace Vehicles.Exceptions
{
    using System;
    public class InvalidTankCapacityException : Exception
    {
        public InvalidTankCapacityException(string message) : base(message)
        {
        }
    }
}
