using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        private string name;
        private int alcohol;
        private int quantity;
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }
        public string Name { get { return name; } set { name = value; } }
        public int Alcohol { get { return alcohol; } set { alcohol = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.AppendLine($"Alcohol: {Alcohol}");

            return sb.ToString().TrimEnd();
        }
    }
}
