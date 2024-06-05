using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Shoot":
                        ShootTarget(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                    case "Add":
                        AddTarget(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                    case "Strike":
                        StrikeTarget(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }

        private static void StrikeTarget(int index, int radiusPower, List<int> targets)
        {
            if (index - radiusPower < 0 || index + radiusPower > targets.Count - 1)
            {
                Console.WriteLine("Strike missed!");

                return;
            }
            else
            {
                targets.RemoveRange(index - radiusPower, (radiusPower * 2) + 1);
            }
        }

        private static void AddTarget(int index, int value, List<int> targets)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                Console.WriteLine("Invalid placement!");

                return;
            }
            else
            {
                targets.Insert(index, value);
            }
        }

        private static void ShootTarget(int index, int power, List<int> targets)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                return;
            }

            targets[index] -= power;

            if (targets[index] <= 0)
            {
                targets.RemoveAt(index);
            }
        }
    }
}
