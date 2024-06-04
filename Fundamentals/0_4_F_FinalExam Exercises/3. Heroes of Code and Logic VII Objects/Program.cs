using System;
using System.Collections.Generic;

namespace _3._Heroes_of_Code_and_Logic_VII_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();

            int addNewHero = int.Parse(Console.ReadLine());
            for (int i = 0; i < addNewHero; i++)
            {
                string[] heroData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroData[0];
                int heroHealth = int.Parse(heroData[1]);
                int heroMana = int.Parse(heroData[2]);

                Hero hero = new Hero()
                {
                    Name = heroName,
                    Health = heroHealth,
                    Mana = heroMana
                };
                heroes.Add(hero);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] action = command.Split(" - ");
                switch (action[0])
                {
                    case "CastSpell":
                        CastSpell(action[1], int.Parse(action[2]), action[3], heroes);
                        break;
                    case "TakeDamage":
                        TakeDamage(action[1], int.Parse(action[2]), action[3], heroes);
                        break;
                    case "Recharge":
                        Recharge(action[1], int.Parse(action[2]), heroes);
                        break;
                    case "Heal":
                        Heal(action[1], int.Parse(action[2]), heroes);
                        break;
                }
            }

            foreach (Hero aliveHero in heroes)
            {
                Console.WriteLine($"{aliveHero.Name}");
                Console.WriteLine($"  HP: {aliveHero.Health}");
                Console.WriteLine($"  MP: {aliveHero.Mana}");
            }
        }

        private static void CastSpell(string heroName, int spellMana, string spellName, List<Hero> heroes)
        {
            Hero hero = heroes.Find(h => h.Name == heroName);          

            if (hero.Mana >= spellMana)
            {
                hero.Mana -= spellMana;
                Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mana} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        private static void TakeDamage(string heroName, int damage, string attacker, List<Hero> heroes)
        {
            Hero hero = heroes.Find(h => h.Name == heroName);

            if (hero.Health > damage)
            {
                hero.Health -= damage;
                Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.Health} HP left!");
            }
            else
            {              
                Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                heroes.Remove(hero);
            }
        }

        private static void Recharge(string heroName, int manaPotion, List<Hero> heroes)
        {
            const int MAX_MANA = 200;

            Hero hero = heroes.Find(h => h.Name == heroName);

            int initialMana = hero.Mana;
            hero.Mana += manaPotion;
            if (hero.Mana >= MAX_MANA)
            {
                hero.Mana = MAX_MANA;
            }
            Console.WriteLine($"{hero.Name} recharged for {hero.Mana - initialMana} MP!");
        }

        private static void Heal(string heroName, int healthPotion, List<Hero> heroes)
        {
            const int MAX_HEALTH = 100;

            Hero hero = heroes.Find(h => h.Name == heroName);

            int initialHealth = hero.Health;
            hero.Health += healthPotion;
            if (hero.Health >= MAX_HEALTH)
            {
                hero.Health = MAX_HEALTH;
            }
            Console.WriteLine($"{hero.Name} healed for {hero.Health - initialHealth} HP!");
        }
    }

    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
    }
}
