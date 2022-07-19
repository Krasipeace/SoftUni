using System;
using System.Linq;

namespace Problem_9
{
    internal class Program
    { // {2, 3, -6, -1, ( 2, -1, 6, 4, ) -8, 8} >>> max sum of continuous ( elements ) = 11
        static void Main(string[] args)
        {
            Console.Write("Enter numbers: ");
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int counter = 0;
            int maxStart = 0;
            int currCounter = 1;
            int currStart = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    currCounter++;

                    if (currCounter > counter)
                    {
                        counter = currCounter;
                        maxStart = currStart;
                    }
                }
                else
                {
                    currCounter = 1;
                    currStart = i;
                }
            }

            int[] result = array.Skip(maxStart).Take(counter).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
