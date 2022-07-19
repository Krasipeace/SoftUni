using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10
{ // {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} >>>> 4 (среща се 5 пъти)
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Dictionary<int, int> sequence = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                if (sequence.ContainsKey(key))
                {
                    int frequency = sequence[key];
                    frequency++;
                    sequence[key] = frequency;
                }
                else
                {
                    sequence.Add(key, 1);
                }
            }

            int minCount = 0;
            int result = -1;

            foreach (var pair in sequence)
            {
                if (minCount < pair.Value)
                {
                    result = pair.Key;
                    minCount = pair.Value;
                }
            }

            Console.WriteLine($"Most repetative element is: {result}");
        }
    }
}
