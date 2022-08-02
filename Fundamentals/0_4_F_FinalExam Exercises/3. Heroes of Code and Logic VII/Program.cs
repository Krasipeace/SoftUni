using System;
using System.Collections.Generic;

namespace _3._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            int inputHeroes = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputHeroes; i++)            //{hero name} {HP} {MP} 
            {
                string[] heroData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroData[0];
                int heroHealth = int.Parse(heroData[1]);
                int heroMana = int.Parse(heroData[2]);

                heroes.Add(heroName, new List<int> { heroHealth, heroMana });
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] action = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                switch (action[0])
                {
                    case "CastSpell":                           //"CastSpell – {hero name} – {MP needed} – {spell name}"
                        CastSpell(action, heroes);
                        break;
                    case "TakeDamage":                          //"TakeDamage – {hero name} – {damage} – {attacker}"
                        TakeDamage(action, heroes);
                        break;
                    case "Recharge":                            //"Recharge – {hero name} – {amount}"
                        Recharge(action, heroes);
                        break;
                    case "Heal":                                //"Heal – {hero name} – {amount}"
                        Heal(action, heroes);
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }

        private static void CastSpell(string[] action, Dictionary<string, List<int>> heroes)
        {
            string heroName = action[1];
            int spellMana = int.Parse(action[2]);
            string spellName = action[3];

            if (heroes[heroName][1] >= spellMana)           //[1] - current Mana
            {
                heroes[heroName][1] -= spellMana;

                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        private static void TakeDamage(string[] action, Dictionary<string, List<int>> heroes)
        {
            string heroName = action[1];
            int damage = int.Parse(action[2]);
            string attacker = action[3];

            if (heroes[heroName][0] > 0)                   //[0] - current Health
            {
                heroes[heroName][0] -= damage;

                if (heroes[heroName][0] <= 0)
                {
                    heroes.Remove(heroName);
                    Console.WriteLine($"{heroName} has been killed by {attacker}!");

                    return;
                }

                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
            }
        }

        private static void Recharge(string[] action, Dictionary<string, List<int>> heroes)
        {
            const int MAX_MP = 200;
            string heroName = action[1];
            int manaPotion = int.Parse(action[2]);

            int initialMana = heroes[heroName][1];

            heroes[heroName][1] += manaPotion;
            if (heroes[heroName][1] >= MAX_MP)
            {
                heroes[heroName][1] = MAX_MP;
            }

            Console.WriteLine($"{heroName} recharged for {heroes[heroName][1] - initialMana} MP!");
        }

        private static void Heal(string[] action, Dictionary<string, List<int>> heroes)
        {
            const int MAX_HP = 100;
            string heroName = action[1];
            int healthPotion = int.Parse(action[2]);

            int initialHealth = heroes[heroName][0];
            heroes[heroName][0] += healthPotion;
            if (heroes[heroName][0] >= MAX_HP)
            {
                heroes[heroName][0] = MAX_HP;
            }

            Console.WriteLine($"{heroName} healed for {heroes[heroName][0] - initialHealth} HP!");
        }
    }
}
