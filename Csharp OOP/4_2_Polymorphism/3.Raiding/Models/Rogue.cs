namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;
        public Rogue(string name) : base(name, ROGUE_POWER)
        {
        }

        public override string CastAbility()
            => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
