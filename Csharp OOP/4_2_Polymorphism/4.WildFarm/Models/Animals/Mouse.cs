namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using FoodTypes;
    public class Mouse : Mammal
    {
        private const double MOUSE_WEIGHT_MODIFIER = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

        public override IReadOnlyCollection<Type> CorrectFood 
            => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };
        protected override double WeightModifier => MOUSE_WEIGHT_MODIFIER;
        public override string ProduceSound() => $"Squeak";
        public override string ToString()
            => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";

    }
}
