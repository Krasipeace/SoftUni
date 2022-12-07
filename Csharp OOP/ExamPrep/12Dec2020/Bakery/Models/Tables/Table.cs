namespace Bakery.Models.Tables
{
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Enums;
    using Bakery.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public bool IsReserved => isReserved;

        public decimal Price => PricePerPerson * numberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            isReserved = true;
            NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            bakedFoods.Add(food);
        }
        public void OrderDrink(IDrink drink)
        {
            drinks.Add(drink);
        }

        public decimal GetBill()
            => bakedFoods.Sum(x => x.Price) + drinks.Sum(x => x.Price) + Price;

        public void Clear()
        {
            isReserved = false;
            numberOfPeople = 0;
            bakedFoods.Clear();
            drinks.Clear();
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb= new StringBuilder();

            sb 
                .AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}
