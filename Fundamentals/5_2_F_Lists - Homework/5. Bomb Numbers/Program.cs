using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = tokens[0];
            int bombPower = tokens[1];

            for (int index = 0; index < numbers.Count; index++)
            {
                int target = numbers[index];
                if (target == bombNumber)
                {
                    BombNumber(numbers, bombPower, index);
                }
            }

            Console.WriteLine(numbers.Sum());
        }

        private static void BombNumber(List<int> numbers, int power, int index)
        {
            int startBombingIndex = Math.Max(0, index - power);
            int endBombingIndex = Math.Min(numbers.Count - 1, index + power);

            for (int i = startBombingIndex; i <= endBombingIndex; i++)
            {
                numbers[i] = 0;
            }
        }

    }
}
