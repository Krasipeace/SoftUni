using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Mu_Online
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeonsRooms = Console.ReadLine().Split('|').ToList();
            int health = 100;
            int bitcoins = 0;

            for (int i = 0; i < dungeonsRooms.Count; i++)
            {
                string[] action = dungeonsRooms[i].Split().ToArray();

                if (action[0] == "potion")
                {
                    health = Potion(health, action);
                }
                else if (action[0] == "chest")
                {
                    bitcoins = Chest(bitcoins, action);
                }
                else
                {
                    string monster = action[0];
                    int attackOfTheMonster = int.Parse(action[1]);

                    health -= attackOfTheMonster;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i + 1}");

                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!", "Bitcoins: {bitcoins}", "Health: {health}");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }

        private static int Chest(int bitcoins, string[] action)
        {
            int treasure = int.Parse(action[1]);
            bitcoins += treasure;
            Console.WriteLine($"You found {treasure} bitcoins.");

            return bitcoins;
        }

        private static int Potion(int health, string[] action)
        {
            int potionHP = int.Parse(action[1]);
            int currentHealth = health;
            health = currentHealth + potionHP;

            if (health > 100)
            {
                health = 100;
            }

            if (health < 100)
            {
                Console.WriteLine($"You healed for {potionHP} hp.");
                Console.WriteLine($"Current health: {health} hp.");
            }
            else if (health == 100)
            {
                Console.WriteLine($"You healed for {100 - currentHealth} hp.");
                Console.WriteLine($"Current health: {health} hp.");
            }

            return health;
        }
    }
}
