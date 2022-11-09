namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using FoodTypes;
    using WildFarm.Models.Contracts;

    public class Cat : Feline
    {
        private const double CAT_WEIGHT_MODIFIER = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override IReadOnlyCollection<Type> CorrectFood
            => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightModifier => CAT_WEIGHT_MODIFIER;

        public override string ProduceSound() => $"Meow";
    }
}
