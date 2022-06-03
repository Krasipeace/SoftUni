using System;
using System.Linq;

namespace _6.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            int leftSum = array.Sum();
            int rightSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                leftSum -= array[i];
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                rightSum += array[i];
            }
            
            if (leftSum != rightSum)
            {
                Console.WriteLine("no");
            }

        }
    }
}
