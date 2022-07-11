using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string DEFAULT_HEALTH = "250";
            const string DEFAULT_DAMAGE = "45";
            const string DEFAULT_ARMOR = "10";

            Dictionary<string, Dictionary<string, int[]>> dragonArmy = new Dictionary<string, Dictionary<string, int[]>>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string type, name, initialDamage, initialHealth, initialArmor;
                ReadDragons(out type, out name, out initialDamage, out initialHealth, out initialArmor);

                if (initialDamage == "null")
                {
                    initialDamage = DEFAULT_DAMAGE;
                }
                if (initialHealth == "null")
                {
                    initialHealth = DEFAULT_HEALTH;
                }
                if (initialArmor == "null")
                {
                    initialArmor = DEFAULT_ARMOR;
                }
                int damage = int.Parse(initialDamage);
                int health = int.Parse(initialHealth);
                int armor = int.Parse(initialArmor);

                AddDragons(dragonArmy, type, name, damage, health, armor);
            }

            PrintDragonArmy(dragonArmy);
        }

        private static void ReadDragons(out string type, out string name, out string initialDamage, out string initialHealth, out string initialArmor)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            type = tokens[0];
            name = tokens[1];
            initialDamage = tokens[2];
            initialHealth = tokens[3];
            initialArmor = tokens[4];
        }

        private static void AddDragons(Dictionary<string, Dictionary<string, int[]>> dragonArmy, string type, string name, int damage, int health, int armor)
        {
            if (!dragonArmy.ContainsKey(type))
            {
                dragonArmy.Add(type, new Dictionary<string, int[]>());
            }
            if (!dragonArmy[type].ContainsKey(name))
            {
                dragonArmy[type].Add(name, new int[3]);
            }

            dragonArmy[type][name][0] = damage;
            dragonArmy[type][name][1] = health;
            dragonArmy[type][name][2] = armor;
        }

        private static void PrintDragonArmy(Dictionary<string, Dictionary<string, int[]>> dragonArmy)
        {
            foreach (var type in dragonArmy)
            {
                int counter = 0;
                double averageDamage = 0.0;
                double averageHealth = 0.0;
                double averageArmor = 0.0;

                foreach (var stats in type.Value)
                {
                    averageDamage += stats.Value[0];
                    averageHealth += stats.Value[1];
                    averageArmor += stats.Value[2];
                    counter++;
                }
                Console.WriteLine($"{type.Key}::({averageDamage / counter:f2}/{averageHealth / counter:f2}/{averageArmor / counter:f2})");

                foreach (var dragon in type.Value.OrderBy(currDrag => currDrag.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}
