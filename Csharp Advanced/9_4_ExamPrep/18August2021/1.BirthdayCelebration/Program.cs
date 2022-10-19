using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> guestsCapacity = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(g => int.Parse(g)).ToArray().Reverse());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToArray());

            int wastedFood = 0;

            while (guestsCapacity.Count > 0 && plates.Count > 0)
            {
                int currentGuests = guestsCapacity.Peek();
                int currentPlates = plates.Peek();

                currentGuests -= currentPlates;
                guestsCapacity.Pop();
                plates.Pop();

                if (currentGuests > 0)
                {
                    guestsCapacity.Push(currentGuests);
                }
                else
                {
                    wastedFood += Math.Abs(currentGuests);
                }
            }
            Console.WriteLine(plates.Count > 0 ? $"Plates: {string.Join(" ", plates)}" : $"Guests: {string.Join(" ", guestsCapacity)}");
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
