using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int index = 0;
           
            Console.WriteLine(Sum(numbers,index));
        }

        static int Sum(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + Sum(numbers, index + 1);
        }
    }
}
