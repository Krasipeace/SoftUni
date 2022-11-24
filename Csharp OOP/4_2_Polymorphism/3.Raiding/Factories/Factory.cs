namespace Raiding.Factories
{
    using System;

    using Contracts;
    using Raiding.Models;
    using Exceptions;

    public class Factory : IFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            BaseHero hero;
            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.INVALID_HERO_EXCEPTION_MESSAGE);
            }

            return hero;
        }
    }
}
