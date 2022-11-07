namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private string name;
        private double weight;
        public Topping(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        private string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TOPPING_TYPE, value));
                }
            }
        }
        private double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value >= 1 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TOPPING_WEIGHT, Name));
                }
            }
        }

        private double GetToppingCaloriesModifier()
        {
            double toppingCaloriesModifier = 0;

            switch (Name.ToLower())
            {
                case "meat":
                    toppingCaloriesModifier = Constants.TOPPING_MEAT;
                    break;
                case "veggies":
                    toppingCaloriesModifier = Constants.TOPPING_VEGGIES;
                    break;
                case "cheese":
                    toppingCaloriesModifier = Constants.TOPPING_CHEESE;
                    break;
                case "sauce":
                    toppingCaloriesModifier = Constants.TOPPING_SAUCE;
                    break;
            }

            return toppingCaloriesModifier;
        }

        internal double GetToppingCalories()
        {
            double toppingCaloriesModifier = GetToppingCaloriesModifier();
            double toppingCalories = Weight * 2 * toppingCaloriesModifier;

            return toppingCalories;
        }
    }
}