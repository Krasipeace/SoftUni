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
            while (true)
            {               
                string command = Console.ReadLine();                
                if ((command = Console.ReadLine()) != "end")
                {
                    break;
                }
                int shootingIndex = int.Parse(command);
                if (shootingIndex > targets.Count)
                {
                    continue;
                }


                
            }
            Console.Write($"Shot targets: {counterShotTargets} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
