using System;
using System.Linq;

namespace Problem_7 //unfinished
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter K = ");
            int numberK = int.Parse(Console.ReadLine());
            Console.Write("Enter numbers (numbers > K): ");
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int numberN = array.Length;
            int sum = 0;
            int finalSum = 0;

            //Array.Sort(array, (a, b) => b.CompareTo(a));

            for (int i = 0; i < numberN; i++)
            {
                if (numberK == array[i])
                {
                    sum += array[i];
                }


                finalSum = sum;
            }

            Console.WriteLine(finalSum);
        }
    }
}
