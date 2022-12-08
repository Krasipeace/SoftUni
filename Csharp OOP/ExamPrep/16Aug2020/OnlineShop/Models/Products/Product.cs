namespace OnlineShop.Models.Products
{
    using System;
    using OnlineShop.Common.Constants;

    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;
        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get { return id; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                id = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                manufacturer = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                model = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get { return overallPerformance; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return string.Format(SuccessMessages.ProductToString, overallPerformance, price, GetType().Name, manufacturer, model, id);
        }
    }
}
