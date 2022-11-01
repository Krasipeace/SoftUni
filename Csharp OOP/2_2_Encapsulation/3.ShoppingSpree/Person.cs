using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public Person()
        {
            products = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
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
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME);
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_AMOUNT_OF_MONEY);
                }
                money = value;
            }
        }
        public void BuyProduct(Product product)
        {
            if (product.Cost > Money)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.INVALID_AMOUNT_OF_MONEY_IN_PERSON, Name, product.Name));
            }

            Money -= product.Cost;
            products.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
        }
        public override string ToString()
        {
            if (products.Count > 0)
            {
                return $"{Name} - {string.Join(", ", products)}";
            }

            return $"{Name} - Nothing bought";
        }
    }
}
