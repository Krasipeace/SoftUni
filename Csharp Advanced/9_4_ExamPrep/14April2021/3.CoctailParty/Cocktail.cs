using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private string name;
        private int capacity;
        private int maxAlcoholLevel;
        private List<Ingredient> ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }
        public string Name { get { return name; } set { name = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int MaxAlcoholLevel { get { return maxAlcoholLevel; } set { maxAlcoholLevel = value; } }
        public List<Ingredient> Ingredients { get { return ingredients; } set { ingredients = value; } }

        public int CurrentAlcoholLevel
        {
            get { return this.Ingredients.Sum(i => i.Alcohol); }
        }

        public void Add(Ingredient ingredient)
        {
            if (this.MaxAlcoholLevel >= ingredient.Alcohol)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            return this.Ingredients.Remove(Ingredients.FirstOrDefault(i => i.Name == name));
        }

        public Ingredient FindIngredient(string name)
        {
            return this.Ingredients.Find(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
