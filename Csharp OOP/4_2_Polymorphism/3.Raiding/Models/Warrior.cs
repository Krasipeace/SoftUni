namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;
        public Warrior(string name) : base(name, WARRIOR_POWER)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
