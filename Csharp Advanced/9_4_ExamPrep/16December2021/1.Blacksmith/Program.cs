using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int GLADIUS = 70;
            const int SHAMSHIR = 80;
            const int KATANA = 90;
            const int SABRE = 110;
            const int BROADSWORD = 150;
            const int INCREASED_VALUE = 5;

            int countGladius = 0;
            int countShamshir = 0;
            int countKatana = 0;
            int countSabre = 0;
            int countBroadsword = 0;

            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ").Select(c => int.Parse(c)).ToArray());

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currSteel = steel.Dequeue();
                int currCarbon = carbon.Pop();
                int craftedSword = currSteel + currCarbon;

                switch (craftedSword)
                {
                    case GLADIUS:
                        countGladius++;
                        break;
                    case SHAMSHIR:
                        countShamshir++;
                        break;
                    case KATANA:
                        countKatana++;
                        break;
                    case SABRE:
                        countSabre++;
                        break;
                    case BROADSWORD:
                        countBroadsword++;
                        break;
                    default:
                        carbon.Push(currCarbon + INCREASED_VALUE);
                        break;
                }
            }
            int craftedSwords = countBroadsword + countGladius + countKatana + countSabre + countShamshir;

            if (craftedSwords > 0)
            {
                Console.WriteLine($"You have forged {craftedSwords} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            Dictionary<string, int> ordered = new Dictionary<string, int>
            {
                {"Broadsword",countBroadsword},
                {"Sabre",countSabre},
                {"Katana",countKatana},
                {"Shamshir",countShamshir},
                {"Gladius",countGladius},
            };
            
            foreach (var item in ordered.OrderBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
