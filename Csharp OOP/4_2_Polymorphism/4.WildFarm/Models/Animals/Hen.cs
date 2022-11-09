namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using WildFarm.Models.FoodTypes;
    public class Hen : Bird
    {
        private const double HEN_WEIGHT_MODIFIER = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }
        public override IReadOnlyCollection<Type> CorrectFood
            => new HashSet<Type>() 
            { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightModifier => HEN_WEIGHT_MODIFIER;

        public override string ProduceSound() => $"Cluck";       
    }
}
