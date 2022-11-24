namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PALADIN_POWER = 100;
        public Paladin(string name) : base(name, PALADIN_POWER)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
    }
}
