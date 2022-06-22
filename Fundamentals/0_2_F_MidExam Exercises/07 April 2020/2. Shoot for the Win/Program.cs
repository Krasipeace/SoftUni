using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            int counterShotTargets = 0;
            string command = string.Empty;
            int shotValue = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int shootingIndex = int.Parse(command);
                
                if (shootingIndex >= 0 && shootingIndex < targets.Count)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        shotValue = targets[shootingIndex];
                        if (targets[i] != -1 && i != shootingIndex)
                        {
                            if (targets[i] > shotValue)
                            {
                                targets[i] -= shotValue;
                            }
                            else
                            {
                                targets[i] += shotValue;
                            }
                        }
                    }

                    targets[shootingIndex] = -1;
                    counterShotTargets++;
                }
            }

            Console.Write($"Shot targets: {counterShotTargets} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
