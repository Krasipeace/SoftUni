using System;

using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;
        public Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get => price;
            private set
            {
                switch (Size)
                {
                    case "Large":
                        price = value;
                        break;
                    case "Middle":
                        price = value * Constants.COCTAIL_PRICE_MIDDLE_MOD;
                        break;
                    case "Small":
                        price = value * Constants.COCTAIL_PRICE_SMALL_MOD;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2}lv";
        }
    }
}
