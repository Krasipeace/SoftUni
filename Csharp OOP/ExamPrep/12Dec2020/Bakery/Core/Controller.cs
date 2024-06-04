namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal allTablesBill;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;
            switch (type)
            {
                case "Bread":
                    bakedFood = new Bread(name, price);
                    break;
                case "Cake":
                    bakedFood = new Cake(name, price);
                    break;
            }
            bakedFoods.Add(bakedFood);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (type)
            {
                case "Tea":
                    drink = new Tea(name, portion, brand);
                    break;
                case "Water":
                    drink = new Water(name, portion, brand);
                    break;
            }
            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }
            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood bakedFood = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (bakedFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(bakedFood);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName);
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return string.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal tableBill = table.GetBill();
            allTablesBill += tableBill;
            table.Clear();

            StringBuilder sb = new StringBuilder();

            sb 
                .AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {tableBill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = tables.FindAll(x => x.IsReserved == false);

            StringBuilder sb = new StringBuilder();

            foreach (var item in freeTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome() => $"Total income: {allTablesBill:f2}lv";
    }
}
