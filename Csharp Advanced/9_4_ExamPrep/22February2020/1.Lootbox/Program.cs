using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int EPIC_VALUE = 100;
            Queue<int> firstLootbox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(l => int.Parse(l)).ToArray());
            Stack<int> secondLootbox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(l => int.Parse(l)).ToArray());
            List<int> claimedItems = new List<int>();

            while (firstLootbox.Count > 0 && secondLootbox.Count > 0)
            {
                int combinedValue = firstLootbox.Peek() + secondLootbox.Peek();

                if (combinedValue % 2 == 0)
                {
                    claimedItems.Add(combinedValue);
                    firstLootbox.Dequeue();
                    secondLootbox.Pop();
                }
                else
                {
                    firstLootbox.Enqueue(secondLootbox.Pop());
                }
            }

            if (firstLootbox.Count > 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (secondLootbox.Count > 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (claimedItems.Sum() >= EPIC_VALUE)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
