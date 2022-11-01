using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.INVALID_NAME);
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_AMOUNT_OF_MONEY);
                }
                cost = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
