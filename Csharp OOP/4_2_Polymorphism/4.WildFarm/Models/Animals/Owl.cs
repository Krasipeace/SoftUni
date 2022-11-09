namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using FoodTypes;
    public class Owl : Bird
    {
        private const double OWL_WEIGHT_MODIFIER = 0.25;
        public Owl(string name, double weight, double wingSize) : base (name, weight, wingSize) { }

        public override IReadOnlyCollection<Type> CorrectFood => new HashSet<Type>() { typeof(Meat) };
        protected override double WeightModifier => OWL_WEIGHT_MODIFIER;
        public override string ProduceSound() => $"Hoot Hoot";
    }
}
