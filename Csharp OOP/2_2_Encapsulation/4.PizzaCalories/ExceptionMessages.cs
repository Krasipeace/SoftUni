namespace PizzaCalories
{
    public class ExceptionMessages
    {
        public const string INVALID_DOUGH_TYPE = "Invalid type of dough.";
        public const string INVALID_DOUGH_WEIGHT = "Dough weight should be in the range [1..200].";

        public const string INVALID_TOPPING_TYPE = "Cannot place {0} on top of your pizza.";
        public const string INVALID_TOPPING_WEIGHT = "{0} weight should be in the range [1..50].";

        public const string INVALID_PIZZA_NAME = "Pizza name should be between 1 and 15 symbols.";
        public const string INVALID_NUMBER_OF_TOPPINGS = "Number of toppings should be in range [0..10].";
    }
}
