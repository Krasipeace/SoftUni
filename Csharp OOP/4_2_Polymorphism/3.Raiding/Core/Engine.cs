namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Factories;
    using Models;
    using Contracts;
    using Raiding.Factories.Contracts;

    public class Engine : IEngine
    {
        private Factory factory;
        private List<BaseHero> heroes;
        public Engine()
        {
            this.factory = new Factory();
            this.heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                string playerName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = factory.CreateHero(heroType, playerName);
                    heroes.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Select(x => x.Power).Sum();

            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}