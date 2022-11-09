namespace WildFarm.Exceptions
{
    using System;
    public class FoodTypeNotEatenException : Exception
    {
        public FoodTypeNotEatenException(string message) : base(message) { }
    }
}
