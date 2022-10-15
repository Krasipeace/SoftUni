using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());
            List<int> plates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();       //defender
            Stack<int> orcs = new Stack<int>();                                                                                               //attacker

            const int THIRD_WAVE = 3;
            for (int currWave = 1; currWave <= wavesOfOrcs; currWave++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray());

                if (currWave % THIRD_WAVE == 0)
                {
                    int addPlate = int.Parse(Console.ReadLine());
                    plates.Add(addPlate);
                }

                GetBattle(plates, orcs);

                if (plates.Count == 0)
                {
                    break;
                }
            }
            PrintBattleResult(plates, orcs);
        }

        static void GetBattle(List<int> plates, Stack<int> orcs)
        {
            while (plates.Count > 0 && orcs.Count > 0)
            {
                int currentOrc = orcs.Peek();
                int currentPlate = plates[0];

                if (currentOrc == currentPlate)
                {
                    orcs.Pop();
                    plates.Remove(currentPlate);
                }
                else if (currentOrc < currentPlate)
                {
                    plates[0] -= currentOrc;
                    orcs.Pop();
                }
                else if (currentOrc > currentPlate)
                {
                    orcs.Push(orcs.Pop() - currentPlate);
                    plates.Remove(currentPlate);
                }
            }
        }
        static void PrintBattleResult(List<int> plates, Stack<int> orcs)
        {
            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}
