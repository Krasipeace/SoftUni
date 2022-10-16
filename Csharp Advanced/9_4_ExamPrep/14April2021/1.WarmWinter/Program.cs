using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            const int INCREASE_HAT_VALUE = 1;
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(h => int.Parse(h)).ToArray());
            Queue<int> scarves = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray());
            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarves.Count > 0)
            {
                int sumForSet = hats.Peek() + scarves.Peek();

                if (hats.Peek() > scarves.Peek())
                {
                    sets.Add(sumForSet);
                    hats.Pop();
                    scarves.Dequeue();
                }
                else if (hats.Peek() < scarves.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarves.Peek())
                {
                    scarves.Dequeue();
                    hats.Push(hats.Pop() + INCREASE_HAT_VALUE);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
