using System;
using System.Linq;

namespace _9._Pokemon_Dont_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (sequence.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int currentValue = 0;

                if (index < 0)
                {
                    currentValue = sequence[0];
                    sum += currentValue;
                    sequence[0] = sequence[sequence.Count - 1];
                }
                else if (index > sequence.Count - 1)
                {
                    currentValue = sequence[sequence.Count - 1];
                    sum += currentValue;
                    sequence[sequence.Count - 1] = sequence[0];
                }
                else
                {
                    currentValue = sequence[index];
                    sum += currentValue;
                    sequence.RemoveAt(index);
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] <= currentValue)
                    {
                        sequence[i]  += currentValue;
                    }
                    else
                    {
                        sequence[i] -= currentValue;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
