using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > Constants.MAX_PIZZA_NAME_LENGTH)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_PIZZA_NAME);
                }

                name = value;
            }
        }
        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }
        private List<Topping> Toppings => toppings;
        
        public double GetCalories()
        {
            double pizzaCalories = 0;

            pizzaCalories += Dough.GetDoughCalories();

            foreach (Topping topping in Toppings)
            {
                pizzaCalories += topping.GetToppingCalories();
            }

            return pizzaCalories;
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count < 0 || Toppings.Count > Constants.MAX_TOPPINGS)
            {
                throw new ArgumentException(ExceptionMessages.INVALID_NUMBER_OF_TOPPINGS);
            }

            toppings.Add(topping);
        }

        public override string ToString() => $"{Name} - {GetCalories():f2} Calories.";
    }
}
