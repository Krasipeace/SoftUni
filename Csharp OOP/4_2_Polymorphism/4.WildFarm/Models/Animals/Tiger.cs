namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using FoodTypes;
    public class Tiger : Feline
    {
        private const double TIGER_WEIGHT_MODIFIER = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }

        public override IReadOnlyCollection<Type> CorrectFood 
            => new HashSet<Type>() { typeof(Meat) };
        protected override double WeightModifier => TIGER_WEIGHT_MODIFIER;
        public override string ProduceSound() => $"ROAR!!!";
    }
}
