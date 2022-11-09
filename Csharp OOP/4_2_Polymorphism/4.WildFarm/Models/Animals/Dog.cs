namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using FoodTypes;
    public class Dog : Mammal
    {
        private const double DOG_WEIGHT_MODIFIER = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }
        protected override double WeightModifier => DOG_WEIGHT_MODIFIER;
        public override IReadOnlyCollection<Type> CorrectFood => new HashSet<Type> { typeof(Meat) };
        public override string ProduceSound() => $"Woof!";

        public override string ToString() 
            => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
