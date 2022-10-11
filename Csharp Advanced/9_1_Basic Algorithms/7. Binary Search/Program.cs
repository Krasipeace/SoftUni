using System;
using System.Linq;

namespace _7._Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(array, key));
        }

        public static int BinarySearch(int[] array, int key)
        {
            int left = 0;
            int right = array.Length;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == key)
                {
                    return mid;
                }
                else if (array[mid] > key)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
    }
}
