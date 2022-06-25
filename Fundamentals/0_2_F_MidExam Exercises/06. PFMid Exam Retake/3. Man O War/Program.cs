using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Man_O_War //The pirates encounter a huge Man-O-War at sea. 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> manowarShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxDeckHealth = int.Parse(Console.ReadLine());

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Retire")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Fire":                                                                                            //attacking warship
                        Fire(int.Parse(tokens[1]), int.Parse(tokens[2]), manowarShip);
                        break;
                    case "Defend":                                                                                          //warship attacking pirateShip
                        Defend(int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), pirateShip);
                        break;
                    case "Repair":                                                                                          //repairing pirateShip
                        Repair(int.Parse(tokens[1]), int.Parse(tokens[2]), maxDeckHealth, pirateShip);
                        break;
                    case "Status":                                                                                          //check number of lowHP decks of pirateShip
                        Status(pirateShip, maxDeckHealth);
                        break;
                }

            }
            int pirateShipSum = 0;
            int warshipSum = 0;
            bool isAnyShipDead = CheckShipDurability(pirateShip, manowarShip);                                              //returns dead or alive ships

            if (!isAnyShipDead)
            {
                for (int i = 0; i < pirateShip.Count; i++)
                {
                    pirateShipSum += pirateShip[i];
                }
                for (int i = 0; i < manowarShip.Count; i++)
                {
                    warshipSum += manowarShip[i];
                }

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warshipSum}");
            }
            else
            {
                return;
            }
        }

        private static bool CheckShipDurability(List<int> pirateShip, List<int> manowarShip)
        {
            bool isAnyShipDead = false;

            for (int i = 0; i < pirateShip.Count; i++)
            {
                if (pirateShip[i] <= 0)
                {
                    isAnyShipDead = true;
                    
                }
            }
            for (int i = 0; i < manowarShip.Count; i++)
            {
                if (manowarShip[i] <= 0)
                {
                    isAnyShipDead = true;
                    
                }
            }

            return isAnyShipDead;
        }

        private static void Status(List<int> pirateShip, int maxDeckHealth)
        {
            int counter = 0;
            for (int i = 0; i < pirateShip.Count; i++)
            {
                double damagedDecks = maxDeckHealth * 0.20;
                if (damagedDecks > pirateShip[i])
                {
                    counter++;
                }
            }
            Console.WriteLine($"{counter} sections need repair.");
        }

        private static void Repair(int currentDeck, int health, int maxHealthDeck, List<int> pirateShip)
        {
            if (currentDeck < 0 || currentDeck > pirateShip.Count)
            {
                return;
            }
            else
            {
                if (pirateShip[currentDeck] < maxHealthDeck)
                {
                    pirateShip[currentDeck] += health;
                    if (pirateShip[currentDeck] > maxHealthDeck)
                    {
                        pirateShip[currentDeck] = maxHealthDeck;
                    }
                }
            }
        }

        private static void Defend(int startDeck, int endDeck, int damageDeck, List<int> pirateShip)
        {
            if (startDeck < 0 || endDeck > pirateShip.Count)
            {
                return;
            }
            else
            {
                for (int i = startDeck; i <= endDeck; i++)
                {
                    int currentDeck = i;
                    pirateShip[currentDeck] -= damageDeck;

                    if (pirateShip[i] <= 0)
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");

                        return;
                    }
                }
            }
        }

        private static void Fire(int currentDeck, int damage, List<int> manowarShip)
        {
            if (currentDeck < 0 || currentDeck > manowarShip.Count)
            {
                return;
            }
            else
            {
                int damagedDeck = manowarShip[currentDeck];

                damagedDeck -= damage;
                if (damagedDeck <= 0)
                {
                    Console.WriteLine("You won! The enemy ship has sunken.");

                    return;
                }
                else
                {
                    manowarShip.RemoveAt(currentDeck);
                    manowarShip.Insert(currentDeck, damagedDeck);
                }
            }
        }
    }
}
