using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            int sequenceOne = inputs[0];
            int sequenceTwo = inputs[1];

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            HashSet<int> setFinal = new HashSet<int>();
            

            for (int i = 0; i < sequenceOne; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                setOne.Add(numbers);
            }
            for (int j = 0; j < sequenceTwo; j++)
            {
                int numbers = int.Parse(Console.ReadLine());
                setTwo.Add(numbers);
            }

            foreach (var first in setOne)
            {
                foreach (var second in setTwo)
                {
                    if (first == second)
                    {
                        setFinal.Add(first);
                    }
                }
            }

            foreach (var unique in setFinal)
            {
                Console.Write($"{unique} ");
            }
        }
    }
}
